SiteAngular.Student.config ($stateProvider,$urlRouterProvider)->
    $stateProvider
        .state 'Create',
            url: '/student/create'
            templateUrl:'/Student/Create'
        .state 'List',
            url : '/'
            templateUrl:'/Student/List'
            controller:'List'
        .state 'Edit',
            url:'/students/edit/:id'
            templateUrl: '/Student/Edit'
