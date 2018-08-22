app.directive('myEnter', function () {
    return function (scope, element, attributes) {
        element.bind('keydown keypress', function (e) {
            // Tester si la touche pressée est la touche 'Entree'
            if (e.which === 13) {
                // scope.$apply, permet de court-circuiter le cyle de vie d'angular.
                scope.$apply(function () {
                    // scope.$eval permet d'évaluer (appeler) la fonction demandée.
                    scope.$eval(attributes.myEnter);
                });

                // e.stopPropagation, permet de ne pas propager l'évènement aux éléments HTML parents
                e.stopPropagation();
                // e.preventDefault, permet d'arrêter la propagation de l'évènement en cas d'erreur
                e.preventDefault();
            }

        })
    }
});