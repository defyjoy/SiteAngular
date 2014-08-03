SiteAngular.Student.controller 'List',['$scope','$state','Factory', ($scope,$state,factory) -> 
    init = ->
         factory.query().$promise.then (result)->
                $scope.students = result
                return
         return
         
    init()
        
    $scope.Delete  = (id,idx)->
        factory.remove('id': id).$promise.then (result)->
            $scope.students.splice idx 
            toastr.success "Student Deleted."
            init()
            return
        , (error)->
            toastr.error error.data.Message
            return
        return

    $scope.changeStatus = (id )->
    return
]