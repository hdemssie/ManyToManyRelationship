namespace ManyToManyRelationship.Controllers {

    export class HomeController {
        private MovieResource;
        public movies;
     

        public getMovies() {
            this.movies = this.MovieResource.query();

        }

        constructor(private $resource: angular.resource.IResourceService) {
            this.MovieResource = $resource(`/api/movies/:id`);
            this.getMovies();
        }
    }

    export class AddActorToMovieController {
        private MovieResource;
        public movie;
        public actor;

        public getMovie(id: number) {
            this.MovieResource.get({ id: id })
            }

        public addActorToMovie() {
            this.MovieResource.save({ id: this.MovieResource.id }, this.actor).$promis.then(() => {

                this.movie = null;
                this.actor = null;
                this.$state.go(`home`);
            })
        }
                
       
        constructor(private $resource: angular.resource.IResourceService,
            private $stateParms: ng.ui.IStateParamsService, 
            private $state: ng.ui.IStateService) {
            this.MovieResource = $resource("/api/movies/:id");
            this.movie = this.getMovie($stateParms[`id`]);
        }
   
    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
