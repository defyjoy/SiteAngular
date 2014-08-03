SiteAngular.Student.run(['$rootScope','$state','$stateParams',($rootScope,$state,$stateParams)->
    $rootScope.$on("$stateChangeSuccess",(event, toState, toParams, fromState, fromParams)->
        console.log "route changed"
        return
    )
])

SiteAngular.Student.config ($stateProvider,$urlRouterProvider)->
        
    $stateProvider
        .state 'Start',
            url:''
            templateUrl:'/Student/List'
            controller:'List'
        .state 'List',
            url : '/'
            templateUrl:'/Student/List'
            controller:'List'
        .state 'Create',
            url: '/student/create'
            templateUrl:'/Student/Create'
            controller:'Create'
        .state 'Edit',
            url:'/students/edit/:id'
            templateUrl: '/Student/Edit'
            controller:'Edit'
        