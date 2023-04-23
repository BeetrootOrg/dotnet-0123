function check() 
        {
            const value = document.getElementById("answer").value;
            const text = document.getElementById("text");
            if (value != "-3/2x^2+5/2") 
            {
                document.getElementById("text").innerHTML = 'Упс, не правильно!';
                text.style.color = "red";
            }
            else
            {
                document.getElementById("text").innerHTML = 'Йомайо, правильно!';
                text.style.color = "green";
            }
        }   