angular.module('otimiza',[]).controller('Visualizar', function ($scope, $http) {

    $scope.fotos = [];

    var promise = $http.get('Visualizar/Fotos');
    promise.then(function (retorno) {
        console.log("entrei");
        $scope.fotos = retorno.data;
    }).catch(function (erro) {
        console.log(erro);
    });

});