
function CalculateCredit() {

    if (Validate()) {
        var config = {
            creditSumm: document.getElementById("CreditSumm").value.replace(/\s/g, ""),
            loanTerm: document.getElementById("LoanTerm").value.replace(/\s/g, ""),
            rate: document.getElementById("Rate").value.replace(/\s/g, "")
        }
        $("#SubmitForm").submit();
    }
}

function Validate() {

    var isValideCreditSumm = ValidateCreditSumm(document.getElementById('CreditSumm'));
    var isValideLoanTerm = ValidateLoanTerm(document.getElementById('LoanTerm'));
    var isValideRate = ValidateRate(document.getElementById('Rate'));

    return isValideCreditSumm && isValideLoanTerm && isValideRate;
}
function ValueIsDouble(value) {
    value.value = value.value.replace(/\s/g, "")
    value.value = value.value.replace('\,', ".");
    var numberValue = Number(value.value);

    if (Number.isNaN(numberValue) || numberValue === 0) {
        return false;
    }
    else {
        return true;
    }
}
function ValueIsInteger(value) {
    value.value = value.value.replace(/\s/g, "")
    var numberValue = Number(value.value);

    if (!Number.isNaN(numberValue) && numberValue !== 0) {
        if ((numberValue ^ 0) === numberValue) {
            return true;
        }
        else {
            return false;
        }
    }
}
function Subdivide(value) {
    value.value = value.value.replace(/(\d)(?=(\d\d\d)+([^\d]|$))/g, '$1\u202f');
}
function ValidateCreditSumm(creditSumm) {
    var isCorrect = ValueIsDouble(creditSumm);
    if (isCorrect) {
        if (creditSumm.value <= 0) {
            creditSumm.classList.add('is-invalid');
            creditSumm.classList.remove('is-valid');
            isCorrect = false;
        }
        else {
            creditSumm.classList.remove('is-invalid');
            creditSumm.classList.add('is-valid');
        }
        Subdivide(creditSumm);
    }
    else {
        creditSumm.classList.add('is-invalid');
        creditSumm.classList.remove('is-valid');
    }
    return isCorrect;
}
function ValidateLoanTerm(loanTerm) {
    var isCorrect = ValueIsInteger(loanTerm);
    if (isCorrect) {
        if (loanTerm.value <= 0) {
            loanTerm.classList.add('is-invalid');
            loanTerm.classList.remove('is-valid');
            isCorrect = false;
        }
        else {
            loanTerm.classList.remove('is-invalid');
            loanTerm.classList.add('is-valid');
        }
        Subdivide(loanTerm);
    }
    else {
        loanTerm.classList.add('is-invalid');
        loanTerm.classList.remove('is-valid');
    }
    return isCorrect;
}
function ValidateRate(rate) {
    var isCorrect = ValueIsDouble(rate);
    if (isCorrect) {
        if (rate.value < 0 || rate.value >100) {
            rate.classList.add('is-invalid');
            rate.classList.remove('is-valid');
            isCorrect = false;
        }
        else {
            rate.classList.remove('is-invalid');
            rate.classList.add('is-valid');
        }
        Subdivide(rate);
    }
    else {
        rate.classList.add('is-invalid');
        rate.classList.remove('is-valid');
    }
    return isCorrect;
}
