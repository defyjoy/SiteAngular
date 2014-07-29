SiteAngular.Student.controller 'Create',['$scope','$state','Factory', ($scope,$state,Factory) -> 
    $scope.Create=(student)->
        Factory.save(student).$promise.then (result)->
            console.log result
            $state.go 'List'
]

