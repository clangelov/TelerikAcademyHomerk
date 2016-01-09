var express = require('express');

module.exports = function(app, config) {
    app.use(express.static(config.rootPath + '/public'));
    app.set('view engine', 'jade');
    app.set('views', config.rootPath + '/server/views');
};