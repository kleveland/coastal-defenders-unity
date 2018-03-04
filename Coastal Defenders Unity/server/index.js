const express = require('express'),
    mysql = require('mysql'),
    app = express();


let config = {
    ip: "localhost",
    port: 4000,
    database: {
        host: "localhost",
        user: "root",
        password: "",
        database: "coastaldefenders",
        port: 3306
    }
};


config.port = process.env.OPENSHIFT_NODEJS_PORT || 4000;
config.ip = process.env.OPENSHIFT_NODEJS_IP || '127.0.0.1';

if (process.env.OPENSHIFT_MYSQL_PASSWORD) {
    config.database.host = process.env.MYSQL_SERVICE_HOST;
    config.database.port = process.env.MYSQL_SERVICE_PORT;
    config.database.user = process.env.OPENSHIFT_MYSQL_USER;
    config.database.password = process.env.OPENSHIFT_MYSQL_PASSWORD;
    config.database.database = process.env.OPENSHIFT_MYSQL_DATABASE;
}

var con = mysql.createConnection({
    host: config.database.host,
    user: config.database.user,
    password: config.database.password,
    database: config.database.database,
    port: config.database.port
});

function getScores(cb) {
    con.query("SELECT * FROM leaderboards", function (err, result, fields) {
        if (err) throw err;
        console.log(result);
        cb(result);
    })
}

app.get('/leaderboard/scores', (req, res) => {
    getScores((result) => {
        let obj = {Items: result};
        console.log(obj);
        res.send(obj);
    })
})

let serv = app.listen(config.port, config.ip, () => console.log('Example app listening ' + config.ip + ':' + config.port + '!'))