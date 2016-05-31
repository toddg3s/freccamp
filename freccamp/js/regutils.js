function AddCamper(id, name, parentname, email, phone, riderLevel, Notes) {
    var list = document.getElementById('camperlist');
    var camperdiv = document.createElement('div');
    camperdiv.id = 'camper_' + id;
    camperdiv.className = 'camperdetail';

    // Name
    var entry = document.createElement('div');
    entry.className = 'formentry';
    var remove = document.createElement('input');
    remove.type = 'button';
    remove.value = 'Remove the camper below';
    remove.onclick = function () { removeCamper(id); updatePrice(); };
    entry.appendChild(remove);
    camperdiv.appendChild(entry);
    var label = document.createElement('div');
    label.className = 'formlabel';
    var txt = document.createTextNode('Name:');
    label.appendChild(txt);
    camperdiv.appendChild(label);
    entry = document.createElement('div');
    entry.className = 'formentry';
    var txtbox = document.createElement('input');
    txtbox.type = 'text';
    txtbox.id = 'campername_' + id;
    txtbox.name = 'campername_' + id;
    txtbox.value = name;
    entry.appendChild(txtbox);
    camperdiv.appendChild(entry);

    // Parent Name
    label = document.createElement('div');
    label.className = 'formlabel';
    txt = document.createTextNode('Parent Name:');
    label.appendChild(txt);
    camperdiv.appendChild(label);
    entry = document.createElement('div');
    entry.className = 'formentry';
    txtbox = document.createElement('input');
    txtbox.type = 'text';
    txtbox.id = 'parentname_' + id;
    txtbox.name = 'parentname_' + id;
    txtbox.value = parentname;
    entry.appendChild(txtbox);
    camperdiv.appendChild(entry);
    var note = document.createElement('div');
    note.className = 'formnote';
    txt = document.createTextNode('Only if different from your name above');
    note.appendChild(txt);
    camperdiv.appendChild(note);

    // Email
    label = document.createElement('div');
    label.className = 'formlabel';
    txt = document.createTextNode('Email (optional):');
    label.appendChild(txt);
    camperdiv.appendChild(label);
    entry = document.createElement('div');
    entry.className = 'formentry';
    txtbox = document.createElement('input');
    txtbox.type = 'text';
    txtbox.id = 'camperemail_' + id;
    txtbox.name = 'camperemail_' + id;
    txtbox.value = email;
    entry.appendChild(txtbox);
    camperdiv.appendChild(entry);
    var note = document.createElement('div');
    note.className = 'formnote';
    txt = document.createTextNode('Only if different from your email above');
    note.appendChild(txt);
    camperdiv.appendChild(note);

    // Phone
    label = document.createElement('div');
    label.className = 'formlabel';
    txt = document.createTextNode('Phone (optional):');
    label.appendChild(txt);
    camperdiv.appendChild(label);
    entry = document.createElement('div');
    entry.className = 'formentry';
    txtbox = document.createElement('input');
    txtbox.type = 'text';
    txtbox.id = 'camperphone_' + id;
    txtbox.name = 'camperphone_' + id;
    txtbox.value = phone;
    entry.appendChild(txtbox);
    camperdiv.appendChild(entry);
    var note = document.createElement('div');
    note.className = 'formnote';
    txt = document.createTextNode('Only if different from your phone above');
    note.appendChild(txt);
    camperdiv.appendChild(note);

    // Rider Level
    label = document.createElement('div');
    label.className = 'formlabel';
    txt = document.createTextNode('Rider level:');
    label.appendChild(txt);
    camperdiv.appendChild(label);
    entry = document.createElement('div');
    entry.className = 'formentry';
    // Level 1: No experience
    var rad = document.createElement('input');
    var radtype = document.createAttribute('type');
    radtype.value = 'radio';
    rad.attributes.setNamedItem(radtype);
    var radname = document.createAttribute('name');
    radname.value = 'riderlevel_' + id;
    rad.attributes.setNamedItem(radname);
    var radid = document.createAttribute('id');
    radid.value = 'riderlevel_' + id + '_1';
    rad.attributes.setNamedItem(radid);
    if (riderLevel == 1) {
        rad.checked = true;
    }
    entry.appendChild(rad);
    var lab = document.createElement('label');
    var labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_1';
    lab.attributes.setNamedItem(labfor);
    var labtxt = document.createTextNode(' Level 1: No experience with horse riding');
    lab.appendChild(labtxt);
    entry.appendChild(lab);
    var br = document.createElement('br');
    entry.appendChild(br);

    // Level 2: Some experience, okay with walking
    rad = document.createElement('input');
    radtype = document.createAttribute('type');
    radtype.value = 'radio';
    rad.attributes.setNamedItem(radtype);
    radname = document.createAttribute('name');
    radname.value = 'riderlevel_' + id;
    rad.attributes.setNamedItem(radname);
    radid = document.createAttribute('id');
    radid.value = 'riderlevel_' + id + '_2';
    rad.attributes.setNamedItem(radid);
    if (riderLevel == 2) {
        rad.checked = true;
    }
    entry.appendChild(rad);
    lab = document.createElement('label');
    entry.appendChild(lab);
    labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_2';
    lab.attributes.setNamedItem(labfor);
    labtxt = document.createTextNode(' Level 2: Some experience, okay with walking');
    lab.appendChild(labtxt);
    br = document.createElement('br');
    entry.appendChild(br);

    // Level 3: Experienced, okay with trotting
    rad = document.createElement('input');
    radtype = document.createAttribute('type');
    radtype.value = 'radio';
    rad.attributes.setNamedItem(radtype);
    radname = document.createAttribute('name');
    radname.value = 'riderlevel_' + id;
    rad.attributes.setNamedItem(radname);
    radid = document.createAttribute('id');
    radid.value = 'riderlevel_' + id + '_3';
    rad.attributes.setNamedItem(radid);
    if (riderLevel == 3) {
        rad.checked = true;
    }
    entry.appendChild(rad);
    lab = document.createElement('label');
    entry.appendChild(lab);
    labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_3';
    lab.attributes.setNamedItem(labfor);
    labtxt = document.createTextNode(' Level 3: Experienced, okay with trotting');
    lab.appendChild(labtxt);
    br = document.createElement('br');
    entry.appendChild(br);

    // Level 4: Experienced, okay with cantering
    rad = document.createElement('input');
    radtype = document.createAttribute('type');
    radtype.value = 'radio';
    rad.attributes.setNamedItem(radtype);
    radname = document.createAttribute('name');
    radname.value = 'riderlevel_' + id;
    rad.attributes.setNamedItem(radname);
    radid = document.createAttribute('id');
    radid.value = 'riderlevel_' + id + '_4';
    rad.attributes.setNamedItem(radid);
    if (riderLevel == 4) {
        rad.checked = true;
    }
    entry.appendChild(rad);
    lab = document.createElement('label');
    entry.appendChild(lab);
    labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_4';
    lab.attributes.setNamedItem(labfor);
    labtxt = document.createTextNode(' Level 4: Experienced, okay with cantering');
    lab.appendChild(labtxt);
    br = document.createElement('br');
    entry.appendChild(br);

    // Level 5: Advanced
    rad = document.createElement('input');
    radtype = document.createAttribute('type');
    radtype.value = 'radio';
    rad.attributes.setNamedItem(radtype);
    radname = document.createAttribute('name');
    radname.value = 'riderlevel_' + id;
    rad.attributes.setNamedItem(radname);
    radid = document.createAttribute('id');
    radid.value = 'riderlevel_' + id + '_5';
    rad.attributes.setNamedItem(radid);
    if (riderLevel == 5) {
        rad.checked = true;
    }
    entry.appendChild(rad);
    lab = document.createElement('label');
    entry.appendChild(lab);
    labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_5';
    lab.attributes.setNamedItem(labfor);
    labtxt = document.createTextNode(' Level 5: Advanced');
    lab.appendChild(labtxt);
    br = document.createElement('br');
    entry.appendChild(br);
    camperdiv.appendChild(entry);

    // Notes
    label = document.createElement('div');
    label.className = 'formlabel';
    txt = document.createTextNode('Anything else we should know:');
    label.appendChild(txt);
    camperdiv.appendChild(label);
    entry = document.createElement('div');
    entry.className = 'formentry';
    var notes = document.createElement('textarea');
    notes.name = 'notes_' + id;
    entry.appendChild(notes);
    camperdiv.appendChild(entry);

    list.appendChild(camperdiv);

    updatePrice();

}

function addNewCamper()
{
    var campers = document.getElementsByClassName('camperdetail');
    var id = campers.length + 1;
    AddCamper(id, '', '', '', '', 1, '');
    var name = document.getElementById('campername_' + id);
    if (name) {
        name.focus();
    }
}

function removeCamper(id)
{
    var camper = document.getElementById('camper_' + id);
    if(camper)
    {
        camper.parentElement.removeChild(camper);
    }
    updatePrice();
}

function updatePrice()
{
    var camps = document.getElementsByClassName('campcheck');
    var count = 0;
    for(i=0; i<camps.length;i++)
    {
        if (camps[i].checked) count++;
    }
    var campers = document.getElementsByClassName('camperdetail');

    var price = 450 * count;
    if (campers.length > 1) {
        price = price - 50;
    }

    var totalprice = document.getElementById('totalprice');
    totalprice.innerText = '$' + price;
}