var auth = require('./auth'),
    path = require('path'),
    controllers = require('../controllers');

module.exports = function (app) {

    app.get('/favicon.ico', function (req, res) {
        res.sendFile(path.resolve(__dirname + '/../../favicon.ico'))
    });

    app.get('/home', function(req, res) {
        res.render('../views/home/home');
    });

    app.get('/phones', controllers.phone.getAll);
    app.get('/phones/:id', auth.isAuthenticated, controllers.phone.getDetails);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
    app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);

    app.get('/upload-results', auth.isAuthenticated, controllers.files.getResults);

    app.get('/files/download/:id', controllers.files.download);

    app.post('/signup', controllers.users.postRegister);
    app.get('/signup', controllers.users.getRegister);

    app.get('*', function(req, res) {
        res.redirect('/home');
    });
};