'Xavier Hoskins
'RCET 0265
'Fall 2022
'Shuffle the Deck
'https://github.com/hoskxavi/ShuffleTheDeck

Option Explicit On
Option Strict On

Imports System
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography

Module ShuffleTheDeck
    Sub Main()
        Dim deckOfCards(12, 3) As String
        Dim userInput As String
        Dim retry As Boolean = True
        Dim rank As Integer
        Dim suit As Integer
        Dim count As Integer = 0
        Dim newCard As Boolean = False


        Console.WriteLine("Press ENTER to draw a random card. Enter S to shuffle the deck, or Q to quit:")

        'loop to draw cards continuously until all have been drawn
        Do While retry = True
            userInput = Console.ReadLine()

            If userInput = "Q" Or userInput = "q" Then
                retry = False
                Exit Sub
            ElseIf userInput = "S" Or userInput = "s" Then
                For rank = 0 To 12
                    For suit = 0 To 3
                        deckOfCards(rank, suit) = ""
                    Next
                Next
                Console.WriteLine("Deck has been shuffled.")
            Else
                Do While newCard = False 'loop to continue drawing cards until a new one is dealt
                    rank = DrawACard()
                    suit = SuitSelect()
                    If deckOfCards(rank, suit) = "" Then
                        deckOfCards(rank, suit) = CardBuilder(rank, suit)
                        count += 1
                        newCard = True
                        Console.WriteLine(deckOfCards(rank, suit))
                    ElseIf count = 52 Then
                        For rank = 0 To 12
                            For suit = 0 To 3
                                deckOfCards(rank, suit) = ""
                            Next
                        Next
                        Console.WriteLine("Deck has been shuffled.")
                        newCard = True
                    End If
                Loop

            End If
            newCard = False
        Loop

    End Sub

    'function to generate a random card number
    Function DrawACard() As Integer
        Dim _card As Integer
        Randomize()
        _card = CInt(Int(((13 * Rnd() + 1) - 1)))
        Return _card
    End Function

    'function to generate a random suit number
    Function SuitSelect() As Integer
        Dim suitAssigner As Integer
        Dim _suit As Integer
        Randomize()
        _suit = CInt(Int(((4 * Rnd() + 1) - 1)))
        Return _suit
    End Function

    'function to convert the rank and suit numbers into a string
    Function CardBuilder(cardRank As Integer, cardSuit As Integer) As String
        Dim _card As String
        Dim _rank As String
        Dim _suit As String

        Select Case cardSuit


            Case 0
                _suit = "Clubs"
            Case 1
                _suit = "Hearts"
            Case 2
                _suit = "Spades"
            Case 3
                _suit = "Diamonds"
        End Select

        If cardRank = 0 Then
            _rank = "A"
        ElseIf cardRank = 10 Then
            _rank = "J"
        ElseIf cardRank = 11 Then
            _rank = "Q"
        ElseIf cardRank = 12 Then
            _rank = "K"
        Else
            _rank = CStr(cardRank + 1)
        End If

        _card &= CStr(_rank) & CStr(_suit)
        Return _card
    End Function


End Module
