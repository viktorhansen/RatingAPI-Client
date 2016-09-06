(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("ratingResource", ["$resource", "appSettings", ratingResource])

    function ratingResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/ratings/:id");
    }
}());