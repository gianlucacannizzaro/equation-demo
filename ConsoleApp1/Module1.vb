Module Module1

    Sub Main()
        Dim coefficients() As Single = getCoefficients()
        Dim solutions() As Single = computeSolutionsGradeTwo(coefficients)
        printSolutions(solutions)
        terminateGracefully()
    End Sub

    Private Function getCoefficients() As Single()
        Dim coefficients(2) As Single
        coefficients(0) = getCoefficient("a")
        coefficients(1) = getCoefficient("b")
        coefficients(2) = getCoefficient("c")
        Return coefficients
    End Function

    Private Function getCoefficient(coefficientName As String) As Single
        Do
            Console.WriteLine($"Inserisci il coefficiente {coefficientName}:")
            Dim inputFromTerminal As String = Console.ReadLine()

            If (Information.IsNumeric(inputFromTerminal)) Then
                Return Val(inputFromTerminal)
            Else
                Console.WriteLine("Il valore inserito non è un numero, riprovare")
            End If

        Loop
    End Function

    Private Function computeSolutionsGradeTwo(coefficients() As Single) As Single()

        Dim a = coefficients(0)
        Dim b = coefficients(1)
        Dim c = coefficients(2)

        Dim solutions(1) As Single
        solutions(0) = Single.NaN
        solutions(1) = Single.NaN

        If (a = 0) Then
            If (b <> 0) Then
                Console.WriteLine("L'equazione in realtà è di primo grado...")
                solutions(0) = computeSolutionsGradeOne(b, c)
            Else
                If c = 0 Then
                    Console.WriteLine("Infinite soluzioni!")
                Else
                    Console.WriteLine("Nessuna soluzione!")
                End If
            End If
        Else
                Dim delta = getDelta(a, b, c)
            If (delta < 0) Then
                Console.WriteLine("Nessuna soluzione!")
            Else
                Dim leftSide As Single = -b / (2 * a)
                Dim rightSide As Single = Math.Sqrt(delta) / (2 * a)
                solutions(0) = leftSide + rightSide
                solutions(1) = leftSide - rightSide
            End If
        End If

        Return solutions


    End Function

    Private Function computeSolutionsGradeOne(b As Single, c As Single) As Single
        Return -c / b
    End Function

    Private Function getDelta(a As Single, b As Single, c As Single)
        Return Math.Pow(b, 2) - 4 * a * c
    End Function

    Private Sub printSolutions(solutions() As Single)
        For i As Single = 0 To (solutions.Length - 1)
            If Not (Single.IsNaN(solutions(i))) Then
                Console.WriteLine($"Soluzione numero {i + 1}:{solutions(i)}")
            End If
        Next
    End Sub

    Private Sub terminateGracefully()
        Console.WriteLine("Premere un tasto per terminare l'esecuzione")
        Console.ReadLine()
    End Sub

End Module
