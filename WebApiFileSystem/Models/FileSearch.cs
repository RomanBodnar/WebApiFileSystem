using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;


namespace WebApiFileSystem.Models
{
    public static class FileSearch
    {
        private const int ten = 10485760;
        private const int fifty = 52428800;
        private const int hundred = 104857600;
        public static string[] GetDrives()
        {
            string[] drives = Environment.GetLogicalDrives();
            DriveInfo[] drivers = DriveInfo.GetDrives();
            return drivers.Where(drive => drive.IsReady).Select(drive => drive.Name).ToArray<string>();
        }

        public static DirectoryContent GetTopDirectory(string rootDirectory)
        {
            DirectoryInfo root = new DirectoryInfo(rootDirectory);
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            files = root.GetFiles().Where(f => f.Attributes.HasFlag(FileAttributes.Hidden) == false).ToArray();
            subDirs = root.GetDirectories().Where(dir => dir.Attributes.HasFlag(FileAttributes.Hidden) == false).ToArray();
            return new DirectoryContent { Parent = root.Parent, Files = files, Directories = subDirs };
        }
        public static FilesLength GetFilesSizes(string rootDirectory)
        {
            DirectoryInfo root = new DirectoryInfo(rootDirectory);
            List<FileInfo> filesFound = new List<FileInfo>();
            Stack<DirectoryInfo> dirs = new Stack<DirectoryInfo>();
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                DirectoryInfo currentDir = dirs.Pop();
                DirectoryInfo[] subDirs;
                FileInfo[] files = null;
                try
                {
                    subDirs = currentDir.GetDirectories();
                    files = currentDir.GetFiles();
                }
                catch (UnauthorizedAccessException e)
                {
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    continue;
                }
                
                
                filesFound.AddRange(files);
                foreach (var dir in subDirs)
                    dirs.Push(dir);
            }
            int less_than_ten = filesFound.Where(f => f.Length <= ten).Count();
            int ten_to_fifty = filesFound.Where(f => f.Length > ten && f.Length <= fifty).Count();
            int above_hundred = filesFound.Where(f => f.Length >= hundred).Count();
            return new FilesLength
                        {
                            ToTen = less_than_ten,
                            TenToFifty = ten_to_fifty,
                            AboveHundred = above_hundred
                        };

        }
    }
}