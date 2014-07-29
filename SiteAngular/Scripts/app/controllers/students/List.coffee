SiteAngular.Student.controller 'List',['$scope','$state','Factory', ($scope,$state,Factory) -> 
    Factory.query().$promise.then (result)->
        $scope.students=result
        
        
    $scope.Delete  = (id)-> 
        Factory.remove('id': id)
        $state.transitionTo 'List',{},
            reload:true
            inherit: true
            notify: true
]