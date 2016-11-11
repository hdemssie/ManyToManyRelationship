namespace movieProducts.Controllers {

    export class HomeController {
        private movieResource;
        public movies;
        public movie;

        public getmovies() {

            this.movies = this.movieResource.query();
        }
        public save() {
            this.movieResource.save(this.movie).$promise.then(() => {
                this.movie = null
                this.getmovies();
                                  })

        }


        constructor(private $resource:angular.resource.IResourceService) {
            this.movieResource = $resource("/api/movies");
            this.getmovies();

        }
       
    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
