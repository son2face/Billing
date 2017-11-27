/***
Metronic AngularJS App Main Script
***/

/* Metronic App */
var MetronicApp = angular.module("MetronicApp", [
    "ui.router", 
    "ui.bootstrap", 
    "oc.lazyLoad",  
    "ngSanitize"
]); 

/* Configure ocLazyLoader(refer: https://github.com/ocombe/ocLazyLoad) */
MetronicApp.config(['$ocLazyLoadProvider', function($ocLazyLoadProvider) {
    $ocLazyLoadProvider.config({
        // global configs go here
    });
}]);

/********************************************
 BEGIN: BREAKING CHANGE in AngularJS v1.3.x:
*********************************************/
/**
`$controller` will no longer look for controllers on `window`.
The old behavior of looking on `window` for controllers was originally intended
for use in examples, demos, and toy apps. We found that allowing global controller
functions encouraged poor practices, so we resolved to disable this behavior by
default.

To migrate, register your controllers with modules rather than exposing them
as globals:

Before:

```javascript
function MyController() {
  // ...
}
```

After:

```javascript
angular.module('myApp', []).controller('MyController', [function() {
  // ...
}]);

Although it's not recommended, you can re-enable the old behavior like this:

```javascript
angular.module('myModule').config(['$controllerProvider', function($controllerProvider) {
  // this option might be handy for migrating old apps, but please don't use it
  // in new ones!
  $controllerProvider.allowGlobals();
}]);
**/

//AngularJS v1.3.x workaround for old style controller declarition in HTML
MetronicApp.config(['$controllerProvider', function($controllerProvider) {
  // this option might be handy for migrating old apps, but please don't use it
  // in new ones!
  $controllerProvider.allowGlobals();
}]);

/********************************************
 END: BREAKING CHANGE in AngularJS v1.3.x:
*********************************************/

/* Setup global settings */
MetronicApp.factory('settings', ['$rootScope', function($rootScope) {
    // supported languages
    var settings = {
        layout: {
            pageSidebarClosed: false, // sidebar menu state
            pageContentWhite: true, // set page content layout
            pageBodySolid: false, // solid body color state
            pageAutoScrollOnLoad: 1000 // auto scroll to top on page load
        },
        assetsPath: '/views/assets',
        globalPath: '/views/assets/global',
        layoutPath: '/views/assets/layouts/layout3',
    };

    $rootScope.settings = settings;

    return settings;
}]);

/* Setup App Main Controller */
MetronicApp.controller('AppController', ['$scope', '$rootScope', function($scope, $rootScope) {
    $scope.$on('$viewContentLoaded', function() {
        App.initComponents(); // init core components
        //Layout.init(); //  Init entire layout(header, footer, sidebar, etc) on page load if the partials included in server side instead of loading with ng-include directive 
    });
}]);

/***
Layout Partials.
By default the partials are loaded through AngularJS ng-include directive. In case they loaded in server side(e.g: PHP include function) then below partial 
initialization can be disabled and Layout.init() should be called on page load complete as explained above.
***/

/* Setup Layout Part - Header */
MetronicApp.controller('HeaderController', ['$scope', function($scope) {
    $scope.$on('$includeContentLoaded', function() {
        Layout.initHeader(); // init header
    });
}]);

/* Setup Layout Part - Sidebar */
MetronicApp.controller('SidebarController', ['$scope', function($scope) {
    $scope.$on('$includeContentLoaded', function() {
        Layout.initSidebar($state); // init sidebar
    });
}]);

/* Setup Layout Part - Quick Sidebar */
MetronicApp.controller('QuickSidebarController', ['$scope', function($scope) {    
    $scope.$on('$includeContentLoaded', function() {
       setTimeout(function(){
            QuickSidebar.init(); // init quick sidebar        
        }, 2000)
    });
}]);

/* Setup Layout Part - Sidebar */
MetronicApp.controller('PageHeadController', ['$scope', function($scope) {
    $scope.$on('$includeContentLoaded', function() {        
        Demo.init(); // init theme panel
    });
}]);

/* Setup Layout Part - Theme Panel */
MetronicApp.controller('ThemePanelController', ['$scope', function($scope) {    
    $scope.$on('$includeContentLoaded', function() {
        Demo.init(); // init theme panel
    });
}]);

/* Setup Layout Part - Footer */
MetronicApp.controller('FooterController', ['$scope', function($scope) {
    $scope.$on('$includeContentLoaded', function() {
        Layout.initFooter(); // init footer
    });
}]);

/* Setup Rounting For All Pages */
MetronicApp.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {
    // Redirect any unmatched url
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $urlRouterProvider.otherwise("/dashboard.html");  
    
    $stateProvider

        // Dashboard
        .state('dashboard', {
            url: "/dashboard.html",
            templateUrl: "/views/App/views/dashboard.html",            
            data: {pageTitle: 'Admin Dashboard Template'},
            controller: "DashboardController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'MetronicApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before a LINK element with this ID. Dynamic CSS files must be loaded between core and theme css files
                        files: [
                            '/Views/assets/global/plugins/morris/morris.css',                            
                            '/Views/assets/global/plugins/morris/morris.min.js',
                            '/Views/assets/global/plugins/morris/raphael-min.js',                            
                            '/Views/assets/global/plugins/jquery.sparkline.min.js',
                            '/Views/assets/pages/scripts/dashboard.min.js',
                            '/Views/App/js/controllers/DashboardController.js',
                        ] 
                    });
                }]
            }
        })

        // Blank Page
        .state('blank', {
            url: "/blank",
            templateUrl: "/views/App/views/blank.html",            
            data: {pageTitle: 'Blank Page Template'},
            controller: "BlankController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'MetronicApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before a LINK element with this ID. Dynamic CSS files must be loaded between core and theme css files
                        files: [
                            '/views/App/js/controllers/BlankController.js'
                        ] 
                    });
                }]
            }
        })

        // AngularJS plugins
        .state('fileupload', {
            url: "/file_upload.html",
            templateUrl: "/views/App/views/file_upload.html",
            data: {pageTitle: 'AngularJS File Upload'},
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'angularFileUpload',
                        files: [
                            '/views/assets/global/plugins/angularjs/plugins/angular-file-upload/angular-file-upload.min.js',
                        ] 
                    }, {
                        name: 'MetronicApp',
                        files: [
                            '/views/App/js/controllers/GeneralPageController.js'
                        ]
                    }]);
                }]
            }
        })

        // UI Select
        .state('uiselect', {
            url: "/ui_select.html",
            templateUrl: "/views/App/views/ui_select.html",
            data: {pageTitle: 'AngularJS Ui Select'},
            controller: "UISelectController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'ui.select',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '/views/assets/global/plugins/angularjs/plugins/ui-select/select.min.css',
                            '/views/assets/global/plugins/angularjs/plugins/ui-select/select.min.js'
                        ] 
                    }, {
                        name: 'MetronicApp',
                        files: [
                            '/views/App/js/controllers/UISelectController.js'
                        ] 
                    }]);
                }]
            }
        })

        // UI Bootstrap
        .state('danhsachtk', {
            url: "/danhsach_tk.html",
            templateUrl: "/views/App/views/danhsach_tk.html",
            data: {pageTitle: 'Danh sach lien lac IPPhone'},
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'MetronicApp',
                        files: [
                            '/views/App/js/controllers/GeneralPageController.js'
                        ] 
                    }]);
                }] 
            }
        })

        // Tree View
        .state('tree', {
            url: "/tree",
            templateUrl: "/views/App/views/tree.html",
            data: {pageTitle: 'jQuery Tree View'},
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'MetronicApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '/views/assets/global/plugins/jstree/dist/themes/default/style.min.css',

                            '/views/assets/global/plugins/jstree/dist/jstree.min.js',
                            '/views/assets/pages/scripts/ui-tree.min.js',
                            '/views/App/js/controllers/GeneralPageController.js'
                        ] 
                    }]);
                }] 
            }
        })     

        // Form Tools
        .state('formtools', {
            url: "/form-tools",
            templateUrl: "/views/App/views/form_tools.html",
            data: {pageTitle: 'Form Tools'},
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'MetronicApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '/views/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css',
                            '/views/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css',
                            '/views/assets/global/plugins/bootstrap-markdown/css/bootstrap-markdown.min.css',
                            '/views/assets/global/plugins/typeahead/typeahead.css',

                            '/views/assets/global/plugins/fuelux/js/spinner.min.js',
                            '/views/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js',
                            '/views/assets/global/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js',
                            '/views/assets/global/plugins/jquery.input-ip-address-control-1.0.min.js',
                            '/views/assets/global/plugins/bootstrap-pwstrength/pwstrength-bootstrap.min.js',
                            '/views/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js',
                            '/views/assets/global/plugins/bootstrap-maxlength/bootstrap-maxlength.min.js',
                            '/views/assets/global/plugins/bootstrap-touchspin/bootstrap.touchspin.js',
                            '/views/assets/global/plugins/typeahead/handlebars.min.js',
                            '/views/assets/global/plugins/typeahead/typeahead.bundle.min.js',
                            '/views/assets/pages/scripts/components-form-tools-2.min.js',

                            '/views/App/js/controllers/GeneralPageController.js'
                        ] 
                    }]);
                }] 
            }
        })        

        // Date & Time Pickers
        .state('pickers', {
            url: "/pickers",
            templateUrl: "/views/App/views/pickers.html",
            data: {pageTitle: 'Date & Time Pickers'},
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'MetronicApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '/views/assets/global/plugins/clockface/css/clockface.css',
                            '/views/assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css',
                            '/views/assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css',
                            '/views/assets/global/plugins/bootstrap-colorpicker/css/colorpicker.css',
                            '/views/assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css',

                            '/views/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js',
                            '/views/assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js',
                            '/views/assets/global/plugins/clockface/js/clockface.js',
                            '/views/assets/global/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.js',
                            '/views/assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js',

                            '/views/assets/pages/scripts/components-date-time-pickers.min.js',

                            '/views/App/js/controllers/GeneralPageController.js'
                        ] 
                    }]);
                }] 
            }
        })

        // Custom Dropdowns
        .state('dropdowns', {
            url: "/dropdowns",
            templateUrl: "/views/App/views/dropdowns.html",
            data: {pageTitle: 'Custom Dropdowns'},
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'MetronicApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '/views/assets/global/plugins/bootstrap-select/css/bootstrap-select.min.css',
                            '/views/assets/global/plugins/select2/css/select2.min.css',
                            '/views/assets/global/plugins/select2/css/select2-bootstrap.min.css',

                            '/views/assets/global/plugins/bootstrap-select/js/bootstrap-select.min.js',
                            '/views/assets/global/plugins/select2/js/select2.full.min.js',

                            '/views/assets/pages/scripts/components-bootstrap-select.min.js',
                            '/views/assets/pages/scripts/components-select2.min.js',

                            '/views/App/js/controllers/GeneralPageController.js'
                        ] 
                    }]);
                }] 
            }
        }) 

        // Advanced Datatables
        .state('datatablesmanaged', {
            url: "/datatables/managed.html",
            templateUrl: "/views/App/views/datatables/managed.html",
            data: {pageTitle: 'Advanced Datatables'},
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'MetronicApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [                             
                            '/views/assets/global/plugins/datatables/datatables.min.css', 
                            '/views/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css',

                            '/views/assets/global/plugins/datatables/datatables.all.min.js',

                            '/views/assets/pages/scripts/table-datatables-managed.min.js',

                            '/views/App/js/controllers/GeneralPageController.js'
                        ]
                    });
                }]
            }
        })

        // Ajax Datetables
        .state('datatablesajax', {
            url: "/datatables/ajax.html",
            templateUrl: "/views/App/views/datatables/ajax.html",
            data: {pageTitle: 'Ajax Datatables'},
            controller: "GeneralPageController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'MetronicApp',
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '/views/assets/global/plugins/datatables/datatables.min.css', 
                            '/views/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css',
                            '/views/assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css',

                            '/views/assets/global/plugins/datatables/datatables.all.min.js',
                            '/views/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js',
                            '/views/assets/global/scripts/datatable.min.js',

                            '/views/App/js/scripts/table-ajax.js',
                            '/views/App/js/controllers/GeneralPageController.js'
                        ]
                    });
                }]
            }
        })

        // User Profile
        .state("profile", {
            url: "/profile",
            templateUrl: "/views/App/views/profile/main.html",
            data: {pageTitle: 'User Profile'},
            controller: "UserProfileController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'MetronicApp',  
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '/views/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css',
                            '/views/assets/pages/css/profile.css',
                            
                            '/views/assets/global/plugins/jquery.sparkline.min.js',
                            '/views/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js',

                            '/views/assets/pages/scripts/profile.min.js',

                            '/views/App/js/controllers/UserProfileController.js'
                        ]                    
                    });
                }]
            }
        })

        // User Profile Dashboard
        .state("profile.dashboard", {
            url: "/dashboard",
            templateUrl: "/views/App/views/profile/dashboard.html",
            data: {pageTitle: 'User Profile'}
        })

        // User Profile Account
        .state("profile.account", {
            url: "/account",
            templateUrl: "/views/App/views/profile/account.html",
            data: {pageTitle: 'User Account'}
        })

        // User Profile Help
        .state("profile.help", {
            url: "/help",
            templateUrl: "/views/App/views/profile/help.html",
            data: {pageTitle: 'User Help'}      
        })

        // Todo
        .state('todo', {
            url: "/todo",
            templateUrl: "/views/App/views/todo.html",
            data: {pageTitle: 'Todo'},
            controller: "TodoController",
            resolve: {
                deps: ['$ocLazyLoad', function($ocLazyLoad) {
                    return $ocLazyLoad.load({ 
                        name: 'MetronicApp',  
                        insertBefore: '#ng_load_plugins_before', // load the above css files before '#ng_load_plugins_before'
                        files: [
                            '/views/assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css',
                            '/views/assets/apps/css/todo-2.css',
                            '/views/assets/global/plugins/select2/css/select2.min.css',
                            '/views/assets/global/plugins/select2/css/select2-bootstrap.min.css',

                            '/views/assets/global/plugins/select2/js/select2.full.min.js',
                            
                            '/views/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js',

                            '/views/assets/apps/scripts/todo-2.min.js',

                            '/views/App/js/controllers/TodoController.js'  
                        ]                    
                    });
                }]
            }
        })

}]);

/* Init global settings and run the app */
MetronicApp.run(["$rootScope", "settings", "$state", function($rootScope, settings, $state) {
    $rootScope.$state = $state; // state to be accessed from view
    $rootScope.$settings = settings; // state to be accessed from view
}]);