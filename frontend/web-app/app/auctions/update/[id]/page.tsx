import Heading from '@/app/components/Heading';
import React from 'react'
import AuctionForm from '../../AuctionForm';
import { getDetailedViewData } from '@/app/actions/auctionActions';

export default async function Update({params}: {params: {id: string}}) {
  const dataParams = await params;
  const data = await getDetailedViewData(dataParams.id);

  return (
    <div className='mx-auto max-w-[75%] shadow-lg p-10 bg-white rounded-lg'>
      <Heading title='Update your auction' subtitle='Please update your car'/>
      <AuctionForm auction={data}>

      </AuctionForm>
    </div>
  )
}
