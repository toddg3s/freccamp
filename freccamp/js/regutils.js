function AddCamper(id, name, parentname, email, phone, riderLevel, Notes) {
    var list = document.getElementById('camperlist');
    var camperdiv = document.createElement('div');
    camperdiv.id = 'camper_' + id;
    camperdiv.className = 'camperdetail';

    var table = document.createElement('table');
    camperdiv.appendChild(table);
    var tr = document.createElement('tr');
    table.appendChild(tr);
    // Name
    var td = document.createElement('td');
    tr.appendChild(td);
    var txt = document.createTextNode('Name:');
    td.appendChild(txt);
    td = document.createElement('td');
    tr.appendChild(td);
    var txtbox = document.createElement('input');
    txtbox.id = 'campername_' + id;
    var txtboxtype = document.createAttribute('type');
    txtboxtype.value = 'text';
    txtbox.attributes.setNamedItem(txtboxtype);
    var txtboxname = document.createAttribute('name');
    txtboxname.value = 'campername_' + id;
    txtbox.attributes.setNamedItem(txtboxname);
    var txtboxvalue = document.createAttribute('value');
    txtboxvalue.value = name;
    txtbox.attributes.setNamedItem(txtboxvalue);
    td.appendChild(txtbox);
    var remove = document.createElement('input');
    remove.type = 'button';
    remove.style.marginleft = '10px;';
    remove.value = 'Remove this camper';
    remove.onclick = function () { removeCamper(id); };
    td.appendChild(remove);

    // Parent Name
    tr = document.createElement('tr');
    table.appendChild(tr);
    td = document.createElement('td');
    tr.appendChild(td);
    txt = document.createTextNode('Parent Name:');
    td.appendChild(txt);
    td = document.createElement('td');
    tr.appendChild(td);
    txtbox = document.createElement('input');
    txtboxtype = document.createAttribute('type');
    txtboxtype.value = 'text';
    txtbox.attributes.setNamedItem(txtboxtype);
    txtboxname = document.createAttribute('name');
    txtboxname.value = 'parentname_' + id;
    txtbox.attributes.setNamedItem(txtboxname);
    txtboxvalue = document.createAttribute('value');
    txtboxvalue.value = parentname;
    txtbox.attributes.setNamedItem(txtboxvalue);
    td.appendChild(txtbox);
    txt = document.createTextNode(' (If different from your name above)');
    td.appendChild(txt);
    // Email
    tr = document.createElement('tr');
    table.appendChild(tr);
    td = document.createElement('td');
    tr.appendChild(td);
    txt = document.createTextNode('Email:');
    td.appendChild(txt);
    td = document.createElement('td');
    tr.appendChild(td);
    txtbox = document.createElement('input');
    txtboxtype = document.createAttribute('type');
    txtboxtype.value = 'text';
    txtbox.attributes.setNamedItem(txtboxtype);
    txtboxname = document.createAttribute('name');
    txtboxname.value = 'camperemail_' + id;
    txtbox.attributes.setNamedItem(txtboxname);
    txtboxvalue = document.createAttribute('value');
    txtboxvalue.value = email;
    txtbox.attributes.setNamedItem(txtboxvalue);
    td.appendChild(txtbox);
    txt = document.createTextNode(' (If different from your email above)');
    td.appendChild(txt);
    // Phone
    tr = document.createElement('tr');
    table.appendChild(tr);
    td = document.createElement('td');
    tr.appendChild(td);
    txt = document.createTextNode('Phone:');
    td.appendChild(txt);
    td = document.createElement('td');
    tr.appendChild(td);
    txtbox = document.createElement('input');
    txtboxtype = document.createAttribute('type');
    txtboxtype.value = 'text';
    txtbox.attributes.setNamedItem(txtboxtype);
    txtboxname = document.createAttribute('name');
    txtboxname.value = 'camperphone_' + id;
    txtbox.attributes.setNamedItem(txtboxname);
    txtboxvalue = document.createAttribute('value');
    txtboxvalue.value = phone;
    txtbox.attributes.setNamedItem(txtboxvalue);
    td.appendChild(txtbox);
    txt = document.createTextNode(' (If different from your phone above)');
    td.appendChild(txt);
    // Rider Level
    tr = document.createElement('tr');
    table.appendChild(tr);
    td = document.createElement('td');
    tr.appendChild(td);
    txt = document.createTextNode('Rider Level:');
    td.appendChild(txt);
    td = document.createElement('td');
    tr.appendChild(td);
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
    td.appendChild(rad);
    var lab = document.createElement('label');
    td.appendChild(lab);
    var labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_1';
    lab.attributes.setNamedItem(labfor);
    var labtxt = document.createTextNode(' Level 1: No experience with horse riding');
    lab.appendChild(labtxt);
    var br = document.createElement('br');
    td.appendChild(br);

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
    td.appendChild(rad);
    lab = document.createElement('label');
    td.appendChild(lab);
    labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_2';
    lab.attributes.setNamedItem(labfor);
    labtxt = document.createTextNode(' Level 2: Some experience, okay with walking');
    lab.appendChild(labtxt);
    br = document.createElement('br');
    td.appendChild(br);

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
    td.appendChild(rad);
    lab = document.createElement('label');
    td.appendChild(lab);
    labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_3';
    lab.attributes.setNamedItem(labfor);
    labtxt = document.createTextNode(' Level 3: Experienced, okay with trotting');
    lab.appendChild(labtxt);
    br = document.createElement('br');
    td.appendChild(br);

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
    td.appendChild(rad);
    lab = document.createElement('label');
    td.appendChild(lab);
    labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_4';
    lab.attributes.setNamedItem(labfor);
    labtxt = document.createTextNode(' Level 4: Experienced, okay with cantering');
    lab.appendChild(labtxt);
    br = document.createElement('br');
    td.appendChild(br);

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
    td.appendChild(rad);
    lab = document.createElement('label');
    td.appendChild(lab);
    labfor = document.createAttribute('for');
    labfor.value = 'riderlevel_' + id + '_5';
    lab.attributes.setNamedItem(labfor);
    labtxt = document.createTextNode(' Level 5: Advanced');
    lab.appendChild(labtxt);
    br = document.createElement('br');
    td.appendChild(br);

    // Notes
    tr = document.createElement('tr');
    table.appendChild(tr);
    td = document.createElement('td');
    tr.appendChild(td);
    txt = document.createTextNode('Other Notes:');
    td.appendChild(txt);
    td = document.createElement('td');
    tr.appendChild(td);
    var notes = document.createElement('textarea');
    var notesname = document.createAttribute('name');
    notesname.value = 'notes_' + id;
    td.appendChild(notes);

    list.appendChild(camperdiv);
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
}