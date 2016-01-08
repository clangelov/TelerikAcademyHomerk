var path = require('path');
var rootPath = path.normalize(__dirname + '/../');

module.exports = {
    development: {
        rootPath: rootPath,
        db: 'mongodb://localhost/chat-app-db',
        port: process.env.PORT || 3030
    }
};