const express = require('express'),
    mysql = require('mysql'),
    app = express(),
    bodyParser = require("body-parser");

app.use(bodyParser.urlencoded());
app.use(bodyParser.json());


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
    con.query("SELECT * FROM scores ORDER BY total_score DESC LIMIT 10", function (err, result, fields) {
        if (err) throw err;
        console.log(result);
        cb(result);
    })
}

function postScores(dat, cb) {
    let insertDat = [];
    insertDat.push(dat.initials);
    insertDat.push(dat.total_score);
    insertDat.push(dat.land_saved_score);
    insertDat.push(dat.human_protection_score);
    insertDat.push(dat.animal_protection_score);
    console.log(insertDat);
    con.query("INSERT INTO scores (player_initials, total_score,land_saved_score,human_protection_score,animal_protection_score) VALUES (?)", [insertDat], function(err, result) {
       if(err) throw err;
        cb();
    });
}

app.get('/leaderboard/scores', (req, res) => {
    console.log("request found");
    getScores((result) => {
        let obj = {Items: result};
        console.log(obj);
        res.send(obj);
    })
})
app.post('/leaderboardpost', (req,res) => {
    console.log(req.body);
    postScores(req.body, () => {
        res.sendStatus(200);
    })
})

let serv = app.listen(config.port, config.ip, () => console.log('Example app listening ' + config.ip + ':' + config.port + '!'))