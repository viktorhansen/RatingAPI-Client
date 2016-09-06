(function () {
	"use strict";

	angular
        .module("common.services", ["ngAnimate", "ngResource", "rzModule", "ui.bootstrap"])
        .constant("appSettings",
        {
            serverPath: "http://localhost:25269/"
        });
}());