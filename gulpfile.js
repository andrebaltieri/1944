var gulp = require('gulp');
var cssmin = require('gulp-cssmin');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var flatten = require('gulp-flatten');

var paths = {
    css: {
        src: [
            'custom_components/css/lumen.min.css'
        ],
        dest: 'wwwroot/assets/css/',
        file: 'styles-1.0.0.css'
    },
    scripts: {
        src: [
            'custom_components/js/jquery.js',
            'bower_components/bootstrap/dist/js/bootstrap.js',
            'custom_components/js/jquery.validate.js',
            'custom_components/js/additional-methods.min.js',
            'custom_components/js/jquery.validate.unobtrusive.js'      
        ],
        dest: 'wwwroot/assets/js/',
        file: 'scripts-1.0.0.js'
    }
};

gulp.task('css', function () {
    gulp.src(paths.css.src)
        .pipe(concat(paths.css.file))
        .pipe(gulp.dest(paths.css.dest));
});

gulp.task('script', function () {
    return gulp
        .src(paths.scripts.src)
        .pipe(concat(paths.scripts.file))
        .pipe(gulp.dest(paths.scripts.dest))
});

gulp.task('default', ['script', 'css']);