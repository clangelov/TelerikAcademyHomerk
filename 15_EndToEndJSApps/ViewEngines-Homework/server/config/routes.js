var path = require('path');

module.exports = function (app) {

    app.get('/favicon.ico', function (req, res) {
        res.sendFile(path.resolve(__dirname + '/../../favicon.ico'))
    });

    app.get('/home', function(req, res) {
        res.render('../views/home/home');
    });

    app.get('/phones', function(req, res) {
        res.render('../views/phones/phones');
    });

    app.get('/tablets', function(req, res) {
        res.render('../views/tablets/tablets');
    });

    app.get('/wearables', function(req, res) {
        res.render('../views/wearables/wearables');
    });

    app.get('*', function(req, res) {
        res.redirect('/home');
    });
};