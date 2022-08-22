let guitars = [];
let connection = null;
getdata();

async function getdata() {
    fetch('http://localhost:9281/guitar')
        .then(x => x.json())
        .then(y => {
            guitars = y;
            display();
            console.log(y);
        });
}

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:9281/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("GuitarCreated", (user, message) => {
        getdata();
    });

    connection.on("GuitarDeleted", (user, message) => {
        getdata();
    });

    connection.on("GuitarUpdated", (user, message) => {
        getdata();
    });

    connection.onclose
        (async () => {
            await start();
        });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

function display() {
    document.getElementById('guitarresult').innerHTML = "";
    guitars.forEach(g => {
        document.getElementById('guitarresult').innerHTML +=
            '<tr><td>' + g.guitarId +
            '</td><td>' + g.brand +
            '</td><td>' + g.modell +
            '</td><td>' + g.price +
            `</td><td> <button type="button" onclick="showupdate(${g.guitarId})">Update</button> ` +
            `<button type="button" onclick="remove(${g.guitarId})">Delete</button> </td></tr>`;
    });
}

function create() {
    let brandtmp = document.getElementById('createbrand').value;
    let modelltmp = document.getElementById('createmodell').value;
    fetch('http://localhost:9281/guitar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            brand: brandtmp,
            modell: modelltmp
        }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

let guitarId = -1;

function showupdate(id) {
    document.getElementById('updatebrand').value = guitars.find(l => l['guitarId'] == id)['brand'];
    document.getElementById('updatediv').style.display = 'flex';
    document.getElementById('updatediv').style.flexDirection = 'column';
    guitarId = id;

}

function update() {
    document.getElementById('updatediv').style.display = 'none';
    let brandtmp = document.getElementById('updatebrand').value;
    let modelltmp = document.getElementById('updatemodell').value;
    let pricetmp = document.getElementById('updateprice').value;
    fetch('http://localhost:9281/guitar/' + guitarId, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                
                brand: brandtmp,
                modell: modelltmp,
                price: pricetmp
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:9281/guitar/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

