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
        database: "comp585",
        port: 3306
    }
};


config.port = 4000;
config.ip = '127.0.0.1';

var con = mysql.createConnection({
    host: config.database.host,
    user: config.database.user,
    password: config.database.password,
    database: config.database.database,
    port: config.database.port
});

function getScores(cb) {
    con.query("SELECT * FROM scores", function (err, result, fields) {
        if (err) throw err;
        console.log(result);
        cb(result);
    })
}

app.get('/leaderboard/scores', (req, res) => {
    console.log("request found");
    getScores((result) => {
        let obj = {Items: result};
        console.log(obj);
        res.send(obj);
    })
})

let serv = app.listen(config.port, config.ip, () => console.log('Example app listening ' + config.ip + ':' + config.port + '!'))