namespace CustmorSearch.Controllers {

    export class HomeController {
        public MovieResource;
        public movies;

        searchMovies(input:string) {
            this.movies = this.MovieResource.searchByDirector({ text: input });
        }

        constructor(private $resource: angular.resource.IResourceService) {
            this.MovieResource = $resource(`/api/movies/:id`, null, {
                searchByDirector: {
                    method: `GET`,
                    url: `/api/movies/search/:text`,
                    isArray: true
                }

            });
        }
    }



    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
