

    interface IOrder extends ng.resource.IResource<IOrder> {
        id: number;
        firstName: string;
        lastName: string;
    }

    export interface IOrdersResource extends ng.resource.IResourceClass<IOrder> {

    }

    export class OrderResource {
        public static Get($resource: ng.resource.IResourceService, apiUrl): IOrdersResource {
            return <IOrdersResource> $resource('http://local.spa.com/api/orders/:id', { id: '@id' }, {});
        }
    }
