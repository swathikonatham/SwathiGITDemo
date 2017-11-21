global with sharing class cc_ccr_api_CartValidation /*extends ccrz.cc_api_CartExtension*/ {
    
    /*******global override boolean allowCheckout(Map<String, Object> inputData){
        System.debug(logginglevel.info, 'cc_ccr_api_CartValidation.allowcheckout');     
        ccrz.cc_bean_CartSummary bean = (ccrz.cc_bean_CartSummary)inputData.get(ccrz.cc_api_cartExtension.PARAM_CARTBEAN);
        if(bean != null)
        {
            System.debug(logginglevel.info, 'cc_ccr_api_CartValidation.allowcheckout=' + bean.allowCheckout);       
            return bean.allowCheckout;
        }       
        return true;
    }

    global override Map<String, Object> prepareForSave(Map<String, Object> inputData) {
        ccrz.cc_bean_CartSummary cartData = (ccrz.cc_bean_CartSummary) inputData.get(PARAM_CARTBEAN);
        ccrz__E_Cart__c cart = (ccrz__E_Cart__c) inputData.get(PARAM_CART);
        cart.ccrz__TotalSurcharge__c = cartData.surchargeAmount;
        cart.ccrz__TaxAmount__c = cartData.tax;
        cart.ccrz__TotalDiscount__c = cartData.totalDiscount;
        return inputData;
    }******/
    //Testing GIT Commit
}