(function () {
  'use strict';

  var app = angular.module('app', ['ui.bootstrap', 'smart-table']);

  app.config(function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    $httpProvider.defaults.withCredentials = true;
    delete $httpProvider.defaults.headers.common["X-Requested-With"];
    $httpProvider.defaults.headers.common["Accept"] = "application/json";
    $httpProvider.defaults.headers.common["Content-Type"] = "application/json";
  });

  app.controller('ctrl', function ($scope, $http, $timeout) {

    $scope.instances = [];
    
    $scope.rowCollection = [
        { Name: 'walws12sedpr', IpAddress: '10.1.112.91', Uri: 'http://walws12sedpr.na.tigplc.com', Role: 'webserver' },
        { Name: 'walws13sedpr', IpAddress: '10.1.112.92', Uri: 'http://walws13sedpr.na.tigplc.com', Role: 'webserver' },
        { Name: 'walws14sedpr', IpAddress: '10.1.112.93', Uri: 'http://walws14sedpr.na.tigplc.com', Role: 'webserver' },
        { Name: 'walws15sedpr', IpAddress: '10.1.112.94', Uri: 'http://walws15sedpr.na.tigplc.com', Role: 'webserver' },
        { Name: 'walws16sedpr', IpAddress: '10.1.112.95', Uri: 'http://walws16sedpr.na.tigplc.com', Role: 'webserver' },
        { Name: 'walws17sedpr', IpAddress: '10.1.112.96', Uri: 'http://walws17sedpr.na.tigplc.com', Role: 'webserver' }];

    $scope.alerts = [];

    $scope.addAlert = function (message) {
      $scope.alerts.push({ type: "warning", msg: message });
      $timeout(function () { $scope.closeAlert($scope.alerts.length - 1); }, 3000);
    };

    $scope.closeAlert = function (index) {
      $scope.alerts.splice(index, 1);
    };

    $scope.getInstances = function () {
      return $http.get('/api/instance/')
        .then(function (res) {
          angular.forEach(res.data, function (item) {
            $scope.instances.push(item);
          });
          return $scope.instances;
        },
        function (res) {
            alert(res.statusText || "Unable to connect to localhost/server");
        });
    };
  });
})();
