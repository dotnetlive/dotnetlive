/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var paths = {
    defaultwebroot: "./wwwroot/default/",
    defaultweb: {},
};

paths.defaultweb.js = paths.defaultwebroot + "js/**/*.js";
paths.defaultweb.minJs = paths.defaultwebroot + "js/**/*.min.js";
paths.defaultweb.css = paths.defaultwebroot + "css/**/*.css";
paths.defaultweb.minCss = paths.defaultwebroot + "css/**/*.min.css";
paths.defaultweb.concatJsDest = paths.defaultwebroot + "js/site.min.js";
paths.defaultweb.concatCssDest = paths.defaultwebroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.defaultweb.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.defaultweb.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    gulp.src([paths.defaultweb.js, "!" + paths.defaultweb.minJs], { base: "." })
        .pipe(concat(paths.defaultweb.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    gulp.src([paths.defaultweb.css, "!" + paths.defaultweb.minCss])
        .pipe(concat(paths.defaultweb.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("default", ["min:js", "min:css"]);
