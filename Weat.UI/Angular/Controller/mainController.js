var mainController = function ($scope, $http,apiService) {
    var id = $scope.id;
    var personUpdate;
    getPerson();

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
    function set(personUpdate) {
        apiService.setPerson(person).then(function (d) {
            console.log('ok');
        })
    }
    set(id);
}
angular.module('app')
    .controller('mainController', mainController);