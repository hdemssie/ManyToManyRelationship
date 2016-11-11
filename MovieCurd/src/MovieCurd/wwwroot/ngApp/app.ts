namespace MovieCurd {

    angular.module('MovieCurd', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: MovieCurd.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: MovieCurd.Controllers.AboutController,
                controllerAs: 'controller'
            })

            .state(`addMovie`, {

                url: `/addmovie`,
                templateUrl: `/ngApp/views/addMovie.html`,
                controller: MovieCurd.Controllers.AddMovieController,
                controllerAs: `controller`
            })
            .state(`editMovie`, {
                url: `/editMovie/:id`,
            templateUrl: `/ngApp/views/editMovie.html`,
            controller: MovieCurd.Controllers.EditMovieController,
            controllerAs: `controller`
            })

            .state(`deleteMovie`, {
                url: `/deleteMovie/:id`,
                templateUrl:`/ngApp/views/delete.html`,
                controller: MovieCurd.Controllers.DeleteMovieController,
                controllerAs: `controller`

            })

            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });



}
