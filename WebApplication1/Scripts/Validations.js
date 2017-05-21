function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName').value == "") {
        return 'First name should not be empty';
    } else {
        return "";
    }
}

function IsFirstNameInValid() {
    if (document.getElementById('TxtFName').value.indexOf("@")!=-1) {
        return 'First name should not contain @';
    } else {
        return "";
    }
}

    function IsLastNameInValid() {
        if (document.getElementById('TxtLName').value.length >= 21) {
            return 'Last Name should not contain more than 5 character';
        } else {
            return "";
        }
}

function IsSalaryEmpty() {
    if (document.getElementById('TxtSalary').value == "") {
        return "Salary should not be empty";
    } else {
        return "";
        }
    }

function IsSalaryInValid() {
    if (isNaN(document.getElementById('TxtSalary').value )) {
        return "Enter valid salary";
    } else {
        return "";
    }
}

function IsValid() {
    var FirstNameEmptyMsg = IsFirstNameEmpty();
    var FirstNameIsValidMsg = IsFirstNameInValid();
    var LastNameInvalidMsg = IsLastNameInValid();
    var SalaryEmptyMsg = IsSalaryEmpty();
    var SalaryInvalidMsg = IsSalaryInValid();

    var FinalErrorMsg = "Errors:";

    if (FirstNameEmptyMsg != "") FinalErrorMsg += "\n" + FirstNameEmptyMsg;
    if (FirstNameIsValidMsg != "") FinalErrorMsg += "\n" + FirstNameIsValidMsg
    if (LastNameInvalidMsg != "") FinalErrorMsg += "\n" + LastNameInvalidMsg;
    if (SalaryEmptyMsg != "") FinalErrorMsg += "\n" + SalaryEmptyMsg;
    if (SalaryInvalidMsg != "") FinalErrorMsg += "\n" + SalaryInvalidMsg;

    if (FinalErrorMsg != "Errors:") {
        alert(FinalErrorMsg);
        return false;
    } else {
        return true;
    }

}
