namespace productList.Controllers {

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

            this.MovieResource.save(this.movie).$promise.then(() => {

                this.movie = null;
                this.$state.go(`home`);
            });
        }

        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService) {
            this.MovieResource = this.$resource(`/api/movies`);
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
