SiteAngular.Student.controller 'Edit',['$scope','$state','$stateParams','Factory',($scope,$state,$stateParams,factory)->
    id=$stateParams.id
    student = factory.get id:id
    $scope.student=student
    
    $scope.Update = (id,student)->
        factory.update
            id:id
            studentToupdate:student
        
]