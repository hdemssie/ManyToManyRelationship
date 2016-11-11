namespace demowebapi.Controllers {

    export class HomeController {

        private ProductResource;
        public products;
        public product;

        public getproducts() {

        this.products = this.ProductResource.query();
         }

        constructor(private $resource: angular.resource.IResourceService) {
        this.ProductResource = $resource("/api/products");
        this.getproducts();

        }
        public save() {
            this.ProductResource.save(this.product).$promise.then(() => {
                this.product = null
                this.getproducts();

            })
          
        }
        
    }
    
    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
