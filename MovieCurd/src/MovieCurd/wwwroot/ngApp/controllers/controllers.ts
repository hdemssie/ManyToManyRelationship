namespace MovieCurd.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
        public movies;
        public MovieResource;

        public getMovies() {

            this.movies = this.MovieResource.query();
        }

        constructor(private $resource: angular.resource.IResourceService) {
            this.MovieResource = $resource(`/api/movies`);
            this.getMovies();

        }
    }
    //AddMovieController
    export class AddMovieController {
        public movie;
        public MovieResource
        public save() {
           
            this.MovieResource.save(this.movie).$promise.then(() =>{
               
                console.log("Hi your hitting Me");

                this.movie = null;
                this.$state.go(`home`);
            });
        }

        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService) {
            this.MovieResource = this.$resource(`/api/movies`);
        }
    }

    //EditMovieController

    export class EditMovieController {
        public movie;
        public MovieResource;

        public getMovie(id: number) {
            this.movie = this.MovieResource.get({ id: id });
        }
        //post the movie after making changes
            public saveMovie() {
                this.MovieResource.save(this.movie).$promise.then(() => {
                    this.movie = null;
                    this.$state.go(`home`);

                });
               
        }
        
        constructor(
            private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {

            this.MovieResource = this.$resource(`/api/movies/:id`);
            this.getMovie($stateParams[`id`])


        }
    }
    //DeleteMovieController
    export class DeleteMovieController {
        public movie;
        public MovieResource;

        public getMovie(id: number) {
            this.movie = this.MovieResource.get({ id: id });
        }
        public deleteMovie() {
            this.MovieResource.delete({ id: this.movie.id }).$promise.then(() => {
                this.movie = null
                this.$state.go(`home`);

            })
            
        }
        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.MovieResource = $resource(`/api/movies/:id`);
            this.getMovie($stateParams[`id`]);
        }
    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
