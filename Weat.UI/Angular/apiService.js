angular.module('app').service('apiService', function ($http) {
    var url = 'http://localhost:63708/';
    this.getPerson = function(){
        return $http.get(url + 'api/People');
    }
    this.getPersonById = function (id) {
        return $http.get(url + 'api/People/' + id);
    }
    this.setById = function (person) {
        return $http.put(url + 'api/People/' + person.Id, person);
    }
})