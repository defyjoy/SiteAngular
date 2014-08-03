SiteAngular.Student.controller 'Edit',['$scope','$state','$stateParams','Factory',($scope,$state,$stateParams,factory)->

    factory.get( id:$stateParams.id)
                        .$promise.then (result)->
                            $scope.student=result
                         ,(error)->
                            toastr.error error.data.Message
    
    $scope.Update = (id,student)->
#        console.log id
        if student is undefined
            toastr.error "Please input correct values"
        factory.update(
            id:id
            student)
                .$promise.then (result)->
                    $state.transitionTo 'List',{},
                        reload:true
                        inherit:true
                        notify:true
                 ,(error)->
                    toastr.error error.data
]