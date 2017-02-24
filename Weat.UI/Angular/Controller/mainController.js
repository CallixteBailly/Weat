var mainController = function ($scope, $http,apiService) {
    var id = $scope.id;

    function getPerson() {
        apiService.getPerson().then(function (d) {
            $scope.persons = d.data
        })
    }
    function getPersonData(id) {
        apiService.getPersonById(id).then(function (d) {
            return d.data;
        })
    }
    $scope.set = function set(personUpdate) {
        console.log(personUpdate);
        apiService.setPerson(personUpdate).then(function (d) {
            console.log('ok');
        })
    }
}
angular.module('app')
    .controller('mainController', mainController);