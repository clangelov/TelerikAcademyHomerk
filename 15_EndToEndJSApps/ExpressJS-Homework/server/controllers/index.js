var UsersController = require('./UsersController'),
    FilesController = require('./FilesController'),
    PhoneController = require('./PhoneController');

module.exports = {
    users: UsersController,
    files: FilesController,
    phone: PhoneController
};