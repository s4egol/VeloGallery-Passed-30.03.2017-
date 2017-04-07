angular.module("MyGalleryModule", ["ngRoute", "ngCookies"])

.config([
    "$locationProvider", "$routeProvider", function ($locationProvider, $routeProvider) {
        $routeProvider.when("/Angular/Gallery", {
            templateUrl: "/Views/Angular/Gallery.html",
            controller: "IndexController"
        })
            .when("/Angular/AddImg", {
                templateUrl: "/Views/Angular/AddNewImage.html",
                controller: "AddImgController",
                resolve: {
                    "check": function ($location, $rootScope) {
                        if (!$rootScope.loggedIn) {
                            $location.path('/');
                        }
                    }
                }
            })
            .when("/Angular/Text", {
                templateUrl: "/Views/Angular/Text.html",
                controller: "TextController"
            })
            .when("/Angular/CreateNewAlbum", {
                templateUrl: "/Views/Angular/CreateNewAlbum.html",
                controller: "AlbumController",
                resolve: {
                    "check": function ($location, $rootScope) {
                        if (!$rootScope.loggedIn) {
                            $location.path('/');
                        }
                    }
                }
            })
            .when('/Angular/myAlbums',
                {
                    templateUrl: '/views/Angular/AllMyAlbums.html',
                    controller: 'MyAlbumsController',
                    resolve: {
                        "check": function ($location, $rootScope) {
                            if (!$rootScope.loggedIn) {
                                $location.path('/');
                            }
                        }
                    }
                })
            .when('/Angular/register', {
                templateUrl: '/views/Angular/Registration.html',
                controller: 'RegisterController'
            })
            .otherwise({
                redirectTo: "/Angular/Gallery"
            });
        $locationProvider.html5Mode(true);
    }
])


.controller("IndexController", [
    "$scope", "dataCenter", "$location", function ($scope, dataCenter, $location) {

        $scope.remove = function (url) {
            dataCenter.remove(url).then(function () {
                dataCenter.getAll().then(function (response) {
                    $scope.velo = response.data;
                });
            });
        };

        dataCenter.getAll().then(function (response) {
            $scope.velo = response.data;
        });

    }
])

.controller("AddImgController", [
    "$scope", "dataCenter", function ($scope, dataCenter) {
        $scope.albums = {
            available: [],
            selected: {}
        };

        dataCenter.getAlbumsForCurrentUser().then(function (respons) {
            $scope.albums.available = respons.data;
            $scope.albums.selected = $scope.albums.available[0];
        });

        $scope.add = function () {
            dataCenter.add($scope.img.name, $scope.img.data, $scope.img.description, $scope.albums.selected.id, $scope.img.isTradable)
                .then(function (response) {
                    $scope.img.name = "";
                    $scope.img.data = "";
                    $scope.img.description = "";
                });
        };
    }
])

.controller('MyAlbumsController', ["$scope", "dataCenter",
    function ($scope, dataCenter) {
        $scope.albums = {
            available: [],
            selected: {}
        };

        $scope.getImages = function () {
            dataCenter.getImagesForAlbum($scope.albums.selected.id)
                    .then(function (respons) {
                        $scope.data = respons.data;
                    });
        };

        function getAlbums() {
            dataCenter.getAlbumsForCurrentUser().then(function (respons) {
                $scope.albums.available = respons.data;
                $scope.albums.selected = $scope.albums.available[0];
                getImages();
            });
        };

        getAlbums();
}])

.controller("TextController", [
    "$scope", "$rootScope", function ($scope, $rootScope) {
        $scope.text = "Here you will find some tips on choosing, buying and maintenance of mountain bike, which I hope will facilitate its maintenance and repair. You can decide if my style of riding, to learn how to choose components, and to determine in what price range you should look for a bike to delight and did not disappoint. Importantly, the site has articles about brand manufacturers of mountain bikes with the stories of brands and specific models mountainbikes. This will simplify the task of those who are interested, for instance, than buying a MTB brand Author, it may be advantageous to purchase a Bicycle company Trek of the same type." +

        "If you already are riding on the bumps on his mountain bike for you in a convenient form collected information to care for them, which will also help replace worn components for better. On the website you will find a number of articles about performing complicated tricks and just helpful information that will help you to preserve your health and will make your riding as safe as possible. And how do you actually think helpful whether Biking?" +

        "Articles on the website over bumps – not rewriting occurring at each site, it is really high quality, based not only on theory but also on practice material presented in a simple and understandable way. Video below and like think not only lovers of mountain Biking, enjoy!";

        $scope.isEdit = false;

        $scope.Edit = function () {
            if ($rootScope.role === 'Admin') {
                $scope.isEdit = true;
            }
        }

        $scope.Save = function (changeableText) {
            $scope.text = changeableText;
            $scope.isEdit = false;
        }
    }
])

.controller('LoginController', ["$scope", "$routeParams", "$location", "loginService", "authService", "rootService",
    function ($scope, $routeParams, $location, loginService, authService, rootService) {
        $scope.loginForm = {
            emailAddress: '',
            password: '',
            returnUrl: $routeParams.returnUrl,
            loggedIn: true,
            role: ''
        };

        function greeting() {
            var data = authService.getCredentials();
            if (!!data.userEmail) {
                rootService.setRoots(data.userEmail, data.role, data.userId);
            };

            $scope.loginForm.emailAddress = rootService.getRoots().email;
            $scope.loginForm.role = rootService.getRoots().role;
            $scope.loginForm.loggedIn = rootService.getRoots().loggedIn;
        }

        greeting();

        $scope.login = function () {
            loginService.login($scope.loginForm.emailAddress, $scope.loginForm.password)
                .then(function (result) {
                    $scope.loginForm.loggedIn = true;
                    rootService.setRoots(result.data.Email, result.data.Role, result.data.Id);
                    authService.setCredentials(
                        result.data.Id,
                        result.data.Email,
                        result.data.Password,
                        result.data.RoleId,
                        result.data.Role);
                    if ($scope.loginForm.returnUrl === undefined) {
                        $location.path('/Angular/gallery');
                    } else {
                        $location.path($scope.loginForm.returnUrl);
                    }
                },
                function () {
                    $scope.loginForm.loggedIn = false;
                    $scope.loginForm.emailAddress = '';
                    rootService.removeRoots();
                });
        };

        $scope.logout = function () {
            authService.clearCredentials();
            $scope.loginForm.loggedIn = false;
            rootService.removeRoots();
            $location.path('/');
        }
    }])

.service("rootService", ["$rootScope", function ($rootScope) {
    function setRoots(email, role, id) {
        $rootScope.loggedIn = true;
        $rootScope.email = email;
        $rootScope.role = role;
        $rootScope.id = id;
    };

    function getRoots() {
        return {
            email: $rootScope.email,
            role: $rootScope.role,
            loggedIn: $rootScope.loggedIn
        }
    }

    function removeRoots() {
        $rootScope.loggedIn = false;
        $rootScope.email = '';
        $rootScope.role = '';
        $rootScope.id = '';
    };

    return {
        setRoots: setRoots,
        removeRoots: removeRoots,
        getRoots: getRoots
    }
}])

.service("authService", ["$cookies", function ($cookies) {
    function setCredentials(id, email, password, roleId, role) {
        $cookies.put('userId', id);
        $cookies.put('userEmail', email);
        $cookies.put('userpPassword', password);
        $cookies.put('roleId', roleId);
        $cookies.put('role', role);
    };

    function getCredentials() {
        return {
            userId: $cookies.get('userId'),
            userEmail: $cookies.get('userEmail'),
            userpPassword: $cookies.get('userpPassword'),
            roleId: $cookies.get('roleId'),
            role: $cookies.get('role')
        }
    };

    function clearCreadentials() {
        $cookies.remove('userId');
        $cookies.remove('userEmail');
        $cookies.remove('userpPassword');
        $cookies.remove('roleId');
        $cookies.remove('role');
    };

    return {
        setCredentials: setCredentials,
        getCredentials: getCredentials,
        clearCredentials: clearCreadentials
    }

}])


.service('loginService', ["$http",
    function ($http) {
        function login(emailAddress, password) {
            var respons = $http({
                method: "POST",
                url: 'http://localhost:9026/Account/Login',
                data: {
                    email: emailAddress,
                    password: password
                },
                headers: { 'Accept': 'application/json' }
            });
            return respons;
        }

        return {
            login: login
        }
}])

.controller('RegisterController', ["$scope", "$location", "RegistrationFactory",
    function ($scope, $location, RegistrationFactory) {
        $scope.registerForm = {
            emailAddress: '',
            password: '',
            confirmPassword: '',
            registrationFailure: false
        };

        $scope.register = function () {
            var result = RegistrationFactory($scope.registerForm.emailAddress,
                $scope.registerForm.password,
                $scope.registerForm.confirmPassword);
            result.then(function (result) {
                if (result.data) {
                    $location.path('/Angular/gallery');
                } else {
                    $scope.loginForm.registrationFailure = true;
                }
            }, function () {
                $scope.loginForm.registrationFailure = true;
            });
        }
    }])

.factory('RegistrationFactory', ["$http",
    function ($http) {
        return function (emailAddress, password, confirmPassword) {
            var respons = $http({
                method: "POST",
                url: 'http://localhost:9026/Account/Register',
                data: {
                    email: emailAddress,
                    password: password,
                    confirmPassword: confirmPassword
                },
                headers: { 'Accept': 'application/json' }
            });
            return respons;
        }
    }])

.controller('AlbumController', ["$scope", "dataCenter",
    function ($scope, dataCenter) {
        $scope.message = "";
        $scope.create = function () {
            dataCenter.createAlbum($scope.albumName)
            .then(function (respons) {
                if (respons.data == true)
                    $scope.message = "";
                else
                    $scope.message = "Album already exist!";
            }, function () {
                  alert("Error album creating!");
            });
            //.then(function () {
            //    alert("Album created");
            //}, function () {
            //    alert("Error album creating!");
            //});
        };
    }])

.controller('MyAlbumsController', ["$scope", "dataCenter",
    function ($scope, dataCenter) {
        $scope.albums = {
            available: [],
            selected: {}
        };

        $scope.getImages = function () {
            dataCenter.getImagesForAlbum($scope.albums.selected.id)
                    .then(function (respons) {
                        $scope.data = respons.data;
                    });
        };

        function getAlbums() {
            dataCenter.getAlbumsForCurrentUser().then(function (respons) {
                $scope.albums.available = respons.data;
                $scope.albums.selected = $scope.albums.available[0];
                getImages();
            });
        };

        getAlbums();
    }])

.controller('GalleryHelper', ["$scope",
    function ($scope) {
        $scope.viewer = {
            visible: false,
        };

        $scope.ShowViewer = function (vel) {
            $scope.viewer.visible = true;
            $scope.currentVel = vel;
        }

        $scope.CloseViewer = function () {
            $scope.viewer.visible = false;
        }
}])

.service("dataCenter", ['$http', "$rootScope", function ($http, $rootScope) {

    function createAlbum(albumName) {
        var respons = $http({
            method: "POST",
            url: 'http://localhost:9026/Album/CreateAlbum',
            data: {
                albumName: albumName,
                userEmail: $rootScope.email
            },
            headers: { 'Accept': 'application/json' }
        });
        return respons;
    };

    function getAlbumsForCurrentUser() {
        var respons = $http({
            method: "POST",
            url: 'http://localhost:9026/Album/GetAlbums',
            data: {
                id: $rootScope.id
            },
            headers: { 'Accept': 'application/json' }
        });
        return respons;
    };

    function getImagesForAlbum(albumId) {
        var respons = $http({
            method: "POST",
            url: 'http://localhost:9026/Image/GetImagesForAlbum',
            data: {
                albumId: albumId
            },
            headers: { 'Accept': 'application/json' }
        });
        return respons;
    };

    function add(fileName, data, description, albumId, isTradable) {
        var respons = $http({
            method: "POST",
            url: 'http://localhost:9026/Image/AddImageAjax',
            data: {
                fileName: fileName,
                data: data,
                description: description,
                albumId: albumId,
                isTradable: isTradable === undefined ? false : true
            },
            headers: { 'Accept': 'application/json' }
        });
        return respons;
    };

    function remove(url) {
        return $http({
            method: "POST",
            url: 'http://localhost:9026/Image/DeleteFileAjax',
            data: { url: url },
            headers: { 'Accept': 'application/json' }
        });
    };

    function getAll() {
        var response = $http({
            url: 'http://localhost:9026/Image/GetImages'
        });
        return response;
    }


    return {
        getAlbumsForCurrentUser: getAlbumsForCurrentUser,
        createAlbum: createAlbum,
        getImagesForAlbum: getImagesForAlbum,
        add: add,
        getAll: getAll,
        remove: remove
    }
}])


.directive("fileread", [function () {
    return {
        scope: {
            fileread: "="
        },
        link: function (scope, element, attributes) {
            element.bind("change", function (changeEvent) {
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    scope.$apply(function () {
                        scope.fileread = loadEvent.target.result;
                    });
                }
                reader.readAsDataURL(changeEvent.target.files[0]);
            });
        }
    }
}])