export default function routing($urlRouterProvider, $stateProvider) {
    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state({
            name: 'home',
            url: '/',
            component: 'dashboard',
            resolve: {
                textBinding: function () {
                    return 'dupa';
                },
                number: function () {
                    return 7;
                }
            }
        });
}