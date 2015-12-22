var app = angular.module("ApplicationModule", ["ngRoute"]);


app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/showcontent/:rootDir*',
        {
            templateUrl: 'Scripts/app/html/folderContent.html',
            controller: 'contentController'
        });
    $routeProvider.when('/showcontent',
        {
            templateUrl: 'Scripts/app/html/folderContent.html',
            controller: 'contentController'
        });
    $routeProvider.when('/drives',
        {
            templateUrl: 'Scripts/app/html/drives.html',
            controller: 'drivesController'
        });
    $routeProvider.otherwise(
        {
            redirectTo: '/drives'
        });
}]);
app.controller("drivesController", function ($location, $scope, fileService) {
    loadDrivers();
    function loadDrivers() {
        var promiseGetDrives = fileService.getDrives();
        promiseGetDrives.then(function (pl) {
            $scope.drives = pl.data;
        },
        function (errorPl) {
            $scope.error = 'failure loading drives', errorPl;
        });
    }

});

app.controller("contentController", function ($location, $scope, $routeParams, $window, fileService) {

    $scope.status = false;
    
    if ($routeParams.rootDir == null)
    {
        $location.path("/drives");
    }
    var path = $routeParams.rootDir;
    getContent();
    getSizes();
    function getSizes() {

        fileService.getSizes(path).
        then(function (result) {
            var response = angular.fromJson(result);
            $scope.sizes = response;
            $scope.status = true;
        }, function (error) {
            $window.alert("Sorry, an error occurred: " + error.message);
        });
    }
    function getContent() {
        console.log("contentController getContent()" + path);
        fileService.getDirectoryInfo(path)
        .then(function (result) {
            var response = angular.fromJson(result);
            $scope.content = response;
            $scope.current = path;
        }, function (error) {
            $window.alert("Sorry, an error occurred: " + error.message);
        });
    }

});