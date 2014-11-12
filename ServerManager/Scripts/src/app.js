(function () {
  'use strict';

  var app = angular.module('app', ['ui.bootstrap', 'smart-table', 'ngToast']);

  app.config(function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    $httpProvider.defaults.withCredentials = true;
    delete $httpProvider.defaults.headers.common["X-Requested-With"];
    $httpProvider.defaults.headers.common["Accept"] = "application/json";
    $httpProvider.defaults.headers.common["Content-Type"] = "application/json";
  });

  app.controller('ctrl', function ($scope, $http, $timeout, ngToast) {
    $scope.instances = [];
    $scope.servers = [];
    $scope.serverNames = [];
    $scope.alerts = [];
    $scope.instance = "";
    $scope.server = "";
    $scope.admin = true;

    $scope.addAlert = function (message) {
      ngToast.create(message);
      //$scope.alerts.push({ type: "warning", msg: message });
      //$timeout(function () { $scope.closeAlert($scope.alerts.length - 1); }, 3000);
    };

    $scope.closeAlert = function (index) {
      $scope.alerts.splice(index, 1);
    };

    $scope.getInstances = function (filter) {
      return $http.get('/serverlist/api/instance/' + filter)
        .then(function (res) {
          $scope.instances = [];
          angular.forEach(res.data, function (item) {
            $scope.instances.push(item);
          });
          return $scope.instances;
        },
        function (res) {
          addAlert(res.statusText || "Unable to connect to localhost/server");
        });
    };
    $scope.$watch('instance', function () {
      if ($scope.instance.length > 3) {
        $scope.getServers($scope.instance);
      }
    });

    $scope.getServers = function (filter) {
      return $http.get('/serverlist/api/server/' + filter)
        .then(function (res) {
          $scope.servers = [];
          $scope.serverNames = [];
          angular.forEach(res.data, function (item) {
            $scope.servers.push(item);
            $scope.serverNames.push(item.Name);
          });
          return $scope.servers;
        },
        function (res) {
          addAlert(res.statusText || "Unable to connect to localhost/server");
        });
    };

    $scope.getServerNames = function (filter) {
      var results = [];
      angular.forEach($scope.serverNames, function(item) {
        if (item.match(filter)) {
          results.push(item);
        }
      });
      return results;
    };
  });
})();
