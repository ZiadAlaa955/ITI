#include <iostream>
using namespace std;

struct Node
{
    int Key ;
    string Name;
    Node* pNext;
    Node* pPrev;
} *pStart , *pLast ;

Node* AllocNewNode()
{
    Node* pNode;
    pNode = new Node();

    if (pNode == NULL) exit(0);

    pNode->pNext = pNode->pPrev = NULL;

    cout << "Enter New Key"<<endl;
    cin>> pNode->Key;

    cout<<"Enter New Name : "<<endl;
    cin>>pNode->Name;

    return pNode;
}

void InserNode() ///Sorted List
{
    Node* pNew = AllocNewNode();

    if (pStart == NULL) ///Empty
        pStart = pLast = pNew;
    else
    {
        Node* pSearch = pStart;
        while ((pSearch!=NULL)&&(pSearch->Key < pNew->Key))
            pSearch = pSearch->pNext;

        if (pSearch == pStart) ///Before pStart
        {
            pNew->pNext = pStart;
            pStart->pPrev = pNew;
            pStart = pNew;
        }
        else if (pSearch == NULL) /// Append
        {
            pLast->pNext = pNew;
            pNew->pPrev = pLast;
            pLast = pNew;
        }
        else ///General Case
        {
            pNew->pNext = pSearch;
            pNew->pPrev = pSearch->pPrev;
            pSearch->pPrev->pNext = pNew;
            pSearch->pPrev = pNew;

        }


    }
}


///Append
void AddNode()
{
    Node* pNew = AllocNewNode();

    if (pStart == NULL) ///Empty List
        pStart = pLast = pNew;
    else ///Append , Add After pLast , 1 or More Already Existing
    {
        pLast->pNext = pNew;
        pNew->pPrev = pLast;
        pLast = pNew;
    }
}

void DisplayALL()
{
    Node* pSearch = pStart;

    cout<<"------------------------------- \n";
    while (pSearch != NULL)
    {
        ///Display
         cout << "ID = "<<pSearch->Key<<endl;
        cout<<"Name : "<<pSearch->Name<<endl;
        ///Advance
        pSearch = pSearch->pNext;
    }
}

Node* SearchList ( int Key)
{
    Node* pSearch = pStart;

    while (pSearch != NULL)
    {
        if (Key == pSearch->Key) break;
            //return pSearch;
        pSearch = pSearch->pNext;
        /// pSearch = 0xF200
    }
    //return NULL;
    return  pSearch;
}

void FreeList()
{
    Node* pDelete ;

    while (pStart != NULL)
    {
        pDelete = pStart;
        pStart = pStart->pNext;
        delete pDelete ;
    }
    pLast = NULL;
}

void DisplayNode (int Key)
{
    Node *pDisplay= SearchList(Key);

    if (pDisplay == NULL)
        cout<<"Not Found \n";
    else
        ///Display ALL Date
    {
        cout << "ID = "<<pDisplay->Key<<endl;
        cout<<"Name : "<<pDisplay->Name<<endl;
    }

}

void DeleteNode(int Key)
{
    Node* pDelete = SearchList(Key);

    if (pDelete==NULL) cout <<"Key Not Found \n";
    else
    { ///Found , At Least One Node in List

        ///Only One Node in List
        if (pStart == pLast)
            pStart = pLast = NULL;
        else if (pDelete == pStart)  ///Delete First Node , Delete from pStart
        {
            pStart = pStart->pNext;
            pStart->pPrev = NULL;
         }
         else if (pDelete == pLast) ///Delete Last Node , Delete from pLast
         {
             pLast = pLast->pPrev;
             pLast->pNext = NULL;
         }
         else  ///General Case
         {
            // Node* PrevNode = pDelete->pPrev;
            // Node* NextNode = pDelete->pNext;
            // PrevNode->pNext = pDelete->pNext;
            // NextNode->pPrev = pDelete->pPrev;

            pDelete->pPrev->pNext = pDelete->pNext;
            pDelete->pNext->pPrev = pDelete->pPrev;
         }
        delete pDelete;
    }

}

int main()
{
    for (int i=0 ; i < 7 ; i++)
    {
        InserNode();
        DisplayALL();
    }
        //AddNode();

    /*Node* pFind = SearchList(9);
    if (pFind != NULL)
        cout <<"Node Found"<<endl;*/
/*
    pFind = SearchList(4);
    if (pFind != NULL)
        cout <<"Node Found"<<endl;
    else
        cout<<"Not Found"<<endl;
*/
    //DisplayNode(7);
/*
    DisplayALL();

    DeleteNode(1);

    DisplayALL();

    DeleteNode(3);

    DisplayALL();

    DeleteNode(4);

    DisplayALL();

    DeleteNode(2);

    DisplayALL();
*/

    FreeList();

    return 0;
}
