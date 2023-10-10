@extends('app');

@section('content')


</div>

<h1 style="text-align: center;">
Calculo de IMC
</h1>


<div class="row">
    <div class="col-2"></div>



    <div class="col-8">

        El Índice de Masa Corporal (IMC) es una medida que se utiliza para evaluar el peso corporal de una persona en relación con su altura. Este índice proporciona una indicación general del estado nutricional y puede ayudar a identificar posibles problemas de peso. Para calcular el IMC, se necesitan dos parámetros básicos: el peso de la persona en kilogramos y la altura en metros.</p>

        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Body_mass_index_chart-es.svg/1200px-Body_mass_index_chart-es.svg.png" alt="grafico" width="70%" height="70%">

    </div>




    <div class="col-2"></div>
</div>




<div class="row">

<div class="col-1">



</div>

<div class="col-8">

<form action="{{ route('Calculo') }}" method="post">
@csrf






@if (session('success'))

<h6 class="alert alert-success">{{session('success') }} </h6>

@endif

@error('ci')

<h6 class="alert alert-danger">{{ $message }} </h6>

@enderror

        

    <div class="row">

        <div class="col-6">

            <div class="form-group">

            <label for="edad">Edad:</label>
            <input type="number" class="form-control" id="edad" name="edad" placeholder="Edad " required><br><br>

                

            </div>

        </div>

        <div class="col-6">

        <div class="form-group">

            <label for="altura">Altura (en cm):</label>
            <input type="text"

                    class="form-control" name="altura" id="altura" aria-describedby="helpId" placeholder="Altura" required>
            </div>
            </div>




       
    </div>



    <div class="row">


        <div class="col-6">

            <div class="form-group">
                    <label for="peso">Peso (en kg):</label>
                    <input type="number" class="form-control" id="peso" name="peso" placeholder="Peso" required><br><br>
            </div>
        </div>

        <div class="col-6">

        Seleccione sexo:
        <br>
        <select class="form-select" aria-label="Sexo" name="sexo" required>
            
            <option value="M">Masculino</option>
            <option value="F">Femenino</option>
            
        </select>
        </div>


    </div>
    <button type="submit" class="btn btn-primary">Calcular</button>
</form>    

</div>

<div class="col-3">

</div>


<div>

<div class="row">

<div class="col-2">

</div>

<div class="col-8">



   
</div>

<div class="col-2">

</div>

</div>






</div>







</div>

@endsection

