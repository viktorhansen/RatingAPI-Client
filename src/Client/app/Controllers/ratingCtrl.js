(function () {
    "use strict";
    angular
        .module("ratingsModule")
        .controller("RatingCtrl", ["ratingResource", RatingCtrl]);

    function RatingCtrl(ratingResource) {
        var self = this;

        ratingResource.query(function (data) {
            self.ratings = data;
        });

        self.submit = function () {
            ratingResource.save({ name: self.rating.name, value: self.slider.value }, function (response) {
                self.slider.value = 3;
                self.ratings.push(response);
            }, function (error) {
                self.message = error.data;
            });
        };

        self.delete = function (index, id) {
            ratingResource.delete({ id: id }, function (response) {
                self.ratings.splice(index, 1);
            }, function (error) {
                self.message = error;
            });
        };

        self.slider = {
            value: 3,
            options: {
                showSelectionBar: true,
                floor: 1,
                ceil: 5,
            }
        };
    }
}());