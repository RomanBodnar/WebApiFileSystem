app.service('fileService', function ($http) {
    this.getDrives = function () {
        return $http.get("/api/files/drives");
    };
    this.getDirectoryInfo = function (directory) {
        return $http.get("/api/files/topdir/?rootDir=" + directory).then(function (result) {
            console.log("fileService.getDirectoryInfo  " + directory);
            return result.data;
        });
    };
    this.getSizes = function (directory) {
        return $http.get("/api/files/sizes/?rootdir=" + directory).then(function (result) {
            return result.data;
        });
    };
});