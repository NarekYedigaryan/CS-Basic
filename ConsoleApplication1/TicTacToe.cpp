#include "TicTacToe.h"
#include <iostream>

TicTacToe::TicTacToe()
{
    matrix = new char* [3];
    for (int i = 0; i < 3; i++)
    {
        matrix[i] = new char[3];
    }
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            matrix[i][j] = 0;
        }
    }
    Matrix();
}
void TicTacToe::Matrix()
{
    short count = 0;
    int row;
    int col;
    while (!Check() && count != 9) {
        std::cout << "Enter row - ";
        std::cin >> row;
        std::cout << "Enter column - ";
        std::cin >> col;
        if (row > 2 || col > 2)
        {
            throw std::out_of_range("out of range");
        }
        if (count % 2 == 0) {
            matrix[col][row] = 'X';
        }
        else {
            matrix[col][row] = 'O';
        }
        //std::cout << matrix[col][row];
        count++;
        print();

    }
}



void TicTacToe::print()
{
    for (size_t i = 0; i < 3; i++)
    {
        for (size_t j = 0; j < 3; j++)
        {
            std::cout << matrix[i][j] << " ";
        }
        std::cout << std::endl;
    }

}
bool TicTacToe::Check()
{
    for (int i = 0; i < 3; ++i) {
        if (matrix[i][0] == matrix[i][1] && matrix[i][1] == matrix[i][2] && matrix[i][0] != 0)
            return true;
    }

    for (int i = 0; i < 3; ++i) {
        if (matrix[0][i] == matrix[1][i] && matrix[1][i] == matrix[2][i] && matrix[0][i] != 0)
            return true;
    }

    if ((matrix[0][0] == matrix[1][1] && matrix[1][1] == matrix[2][2] && matrix[0][0] != 0) ||
        (matrix[0][2] == matrix[1][1] && matrix[1][1] == matrix[2][0] && matrix[0][2] != 0))
        return true;

    return false;
}


TicTacToe::~TicTacToe()
{
    for (int i = 0; i < 3; ++i) {
        delete[] matrix[i];
    }
    delete[] matrix;
}