var path = require('path');
var rootPath = path.normalize(__dirname + '/../../');

module.exports = {
    rootPath: rootPath,
    port: 8001,
    db: 'mongodb://localhost/homework-db'
};