var http = require('http');
var util = require('util');
var formidable = require('formidable');
var fs = require('fs');
var uuid = require('node-uuid');

var PORT = 7776;
var UPLOAD_DIR = "./files";

var server = http.createServer(function (request, response) {

    if (request.url === '/upload' && request.method.toLowerCase() === 'post') {

        var uploadedFiles = [];
        var form = new formidable.IncomingForm();

        form.uploadDir = UPLOAD_DIR;
        form.multiples = true;
        form.keepExtensions = true;

        if (!fs.existsSync(UPLOAD_DIR)) {
            fs.mkdirSync(UPLOAD_DIR);
        }

        form.on('fileBegin', function (name, file) {
            var ext = '.' + file.name.split('.').pop();
            var fileGuidName = form.uploadDir + "/" + uuid.v4() + ext;
            uploadedFiles.push(fileGuidName);
            file.path = fileGuidName;
        });

        form.on('progress', function(bytesReceived, bytesExpected) {
            var percentage = (100*(bytesReceived/bytesExpected));
            console.log('Progress so far: '+ percentage +"%");
        });

        form.parse(request, function (err, fields, files) {
            if (err) {
                console.log(err);
            } else {
                response.writeHead(200, {'content-type': 'text/text'});
                var names = uploadedFiles.map(function (uploadedFile) {
                    return uploadedFile.substring(UPLOAD_DIR.length + 1);
                });
                response.write(names.join('[|]'));
                response.end();
            }
        });

    } else if (request.url.substr(0, 10) === '/download/') {
        // Download
        var filePath = './files/' + request.url.substring(10);
        if (!fs.existsSync(filePath)) {
            console.log('File for download does not exist!');
            response.statusCode = 404;
            response.write('File not found!');
            response.end();
            return;
        }

        var stat = fs.statSync(filePath);
        response.writeHead(200, {
            'Content-Length': stat.size
        });
        var readStream = fs.createReadStream(filePath);
        readStream.pipe(response);

    } else if (request.url === '/') {
        // Home
        fs.readFile('./public/index.html', function (err, data) {
            if (err) {
                console.log(err);
            }
            response.end(data);
        });
    } else {
        response.statusCode = 404;
        response.write('404 Not found!');
        response.end();
    }
});

server.listen(PORT);
console.log("Server running on port " + PORT);