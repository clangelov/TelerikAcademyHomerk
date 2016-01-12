var mongoose = require('mongoose'),
    Schema = mongoose.Schema;

var phoneSchema = mongoose.Schema({
    name: String,
    price: Number,
    pic: String,
    details: String
});


var Phone = mongoose.model('Phone', phoneSchema);

module.exports.seedInitialPhones = function() {
    Phone.find({}).exec(function(err, collection) {
        if (err) {
            console.log('Cannot find users: ' + err);
            return;
        }

        if (collection.length === 0) {

            Phone.create({name: 'iPhone 6', price: 699, pic: 'http://i.telegraph.co.uk/multimedia/archive/03058/iphone_6_3058505b.jpg', details: '4.7-inch (diagonal) LED-backlit widescreen Multi-Touch display with IPS technology and New 8-megapixel iSight camera'});
            Phone.create({name: 'Samsusng Galaxy S6', price: 472.99, pic: 'https://www.o2.co.uk/shop/homepage/images/shop15/brand/samsung/s6/samsung-galaxy-gallery-img-5-400-170315.jpeg', details: 'Android v5.0.2 (Lollipop), Quad-Core 1.5 GHz Cortex-A53 + Quad-Core 2.1 GHz Cortex-A57 Processor, Chipset: Exynos 742, Mali-T760 Graphics'});
            Phone.create({name: 'HTC One M9', price: 649.99, pic: 'http://www.phonebunch.com/news-images/2015/03/htc-one-m9-gold.jpg', details: '20 MP camera with sapphire camera cover lens to deliver crisp clear photos'});
            console.log('Phones added to database...');
        }
    });
};