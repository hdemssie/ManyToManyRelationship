namespace ManyToManyRelationship {

    angular.module('ManyToManyRelationship', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: ManyToManyRelationship.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state(`addActorToMovie`, {

                url: `/addActorToMovie/:id`,
                templateUrl: `/ngApp/views/addActorTOMovie.html`,
                controller: ManyToManyRelationship.Controllers.AddActorToMovieController,
                controllerAs: `controller`
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: ManyToManyRelationship.Controllers.AboutController,
                controllerAs: 'controller'
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