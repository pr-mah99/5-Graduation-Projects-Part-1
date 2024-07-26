/* «·Œ«’ »«·„Œ«“‰ view  */
create view view_Stores as
select products.product_id as'«· ”·”·',product_name as'«”„ «·„‰ Ã',type as'«·‰Ê⁄',Expiry as' «—ÌŒ «‰ Â«¡ «·’·«ÕÌ…',Total as'«·«Ã„«·Ì ›Ì «·„Œ“‰' from stores,Products where stores.product_id=Products.product_id

select * from view_Stores

/* «·Œ«’ »«·„‰ Ã«  Ê«·»«—ﬂÊœ view  */
create view Products_Barcode as
select products.product_id as'«· ”·”·',product_name as'«”„ «·„‰ Ã',type as'«·‰Ê⁄',Expiry as' «—ÌŒ «‰ Â«¡ «·’·«ÕÌ…',price_sale as'”⁄— «·»Ì⁄',price_buy as'”⁄— «·‘—«¡',barcode as'»«—ﬂÊœ' from Products,Barcode where Barcode.product_id=Products.product_id


select * from Products_Barcode



/* ﬂÊœ ⁄—÷ «·„‰ Ã«  ›Ì ÃœÊ· «·»Ì⁄  */
select products.product_id as 'Id' ,product_name as 'Product Name' ,type as 'Type',price_buy as 'Price',barcode as 'Barcode',Total as 'Store' from products,Stores,Barcode where Stores.product_id=products.product_id and barcode.product_id=products.product_id 

/* «· ﬁ—Ì— «·‰Â«∆Ì */

select report_id as '«· ”·”·',customer_name as '«·“»Ê‰',username as '«·„ÊŸ›',report_date as ' «—ÌŒ «· ﬁ—Ì—',Total as '«·«Ã„«·Ì «·ﬂ·Ì' from Report,Users, Customer where customer_id=Customer and Employee=user_id


/* «·›« Ê—…*/

select Bill_number as ' ”·”· œ«Œ· «·›« Ê—…',product_name as'«·„‰ Ã',producct_price as'”⁄— «·„‰ Ã',Quantity as '«·ﬂ„Ì…',Subtotal as'√·«Ã„«·Ì «·›—⁄Ì' from Bill,Products where product_id=product


/* «· Œ“Ì‰ «·‰Â«∆Ì*/
select * from Products, stores where Products.product_id=stores.product_id